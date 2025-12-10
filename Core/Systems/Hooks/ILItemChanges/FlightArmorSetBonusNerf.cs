using System.Reflection;
using MonoMod.RuntimeDetour;
using ThoriumMod;
using MonoMod.Cil;
using Mono.Cecil.Cil;

namespace InfernalEclipseAPI.Core.Systems.ILItemChanges
{
    [JITWhenModsEnabled(InfernalCrossmod.Thorium.Name)]
    [ExtendsFromMod(InfernalCrossmod.Thorium.Name)]
    public class FlightArmorSetBonusNerf : ModSystem //I'm not sure if this even does anything but it exists.
    {
        private static ILHook postUpdateEquipsILHook;

        public override void OnModLoad()
        {
            if (!ModLoader.HasMod("ThoriumMod"))
                return;

            MethodInfo target = typeof(ThoriumPlayer).GetMethod(
                "PostUpdateEquips",
                BindingFlags.Instance | BindingFlags.Public);

            postUpdateEquipsILHook = new ILHook(target, EditPostUpdateEquips);
        }

        public override void OnModUnload()
        {
            postUpdateEquipsILHook?.Dispose();
            postUpdateEquipsILHook = null;
        }

        private static void EditPostUpdateEquips(ILContext il)
        {
            var c = new ILCursor(il);

            var playerType = typeof(Player);
            var thoriumPlayerType = typeof(ThoriumPlayer);

            FieldInfo wingsLogicField = playerType.GetField("wingsLogic",
                BindingFlags.Instance | BindingFlags.Public);
            FieldInfo wingTimeMaxField = playerType.GetField("wingTimeMax",
                BindingFlags.Instance | BindingFlags.Public);
            FieldInfo thoriumPlayerPlayerField = thoriumPlayerType.GetField("Player",
                BindingFlags.Instance | BindingFlags.Public);

            // Fledgling values we want to bake into the IL
            int fledglingID = ArmorIDs.Wing.CreativeWings;
            int fledglingTime = ArmorIDs.Wing.Sets.Stats[fledglingID].FlyTime; 

            // Look for pattern:
            //   ldc.i4.1
            //   stfld Player::wingsLogic
            //   ldarg.0
            //   ldfld ThoriumPlayer::Player
            //   ldc.i4.s 30
            //   stfld Player::wingTimeMax
            if (c.TryGotoNext(
                i => i.MatchLdcI4(1),
                i => i.MatchStfld(wingsLogicField),
                i => i.MatchLdarg(0),
                i => i.MatchLdfld(thoriumPlayerPlayerField),
                i => i.MatchLdcI4(30),
                i => i.MatchStfld(wingTimeMaxField)))
            {
                // c.Next is the ldc.i4.1
                Instruction instWingsConst = c.Next;
                Instruction instStfldWings = instWingsConst.Next;
                Instruction instLdarg0 = instStfldWings.Next;
                Instruction instLdfldPlr = instLdarg0.Next;
                Instruction instTimeConst = instLdfldPlr.Next;   // ldc.i4.s 30
                Instruction instStfldTime = instTimeConst.Next;  // stfld wingTimeMax

                // Replace: this.Player.wingsLogic = 1;
                instWingsConst.OpCode = OpCodes.Ldc_I4;
                instWingsConst.Operand = fledglingID;

                // Replace: this.Player.wingTimeMax = 30;
                instTimeConst.OpCode = OpCodes.Ldc_I4;
                instTimeConst.Operand = fledglingTime;
            }
        }
    }
}
