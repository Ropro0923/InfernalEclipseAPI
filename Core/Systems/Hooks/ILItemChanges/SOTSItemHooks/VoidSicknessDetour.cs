using System.Reflection;
using InfernalEclipseAPI.Content.Buffs;
using MonoMod.RuntimeDetour;
using SOTS.Items.Void;

namespace InfernalEclipseAPI.Core.Systems.Hooks.ILItemChanges.SOTSItemHooks
{
    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name)]
    [ExtendsFromMod(InfernalCrossmod.SOTS.Name)]
    public class VoidSicknessDetour : ModSystem
    {
        private static Hook voidSicknessDebuffDetour = null;

        public override void OnModLoad()
        {
            if (InfernalCrossmod.SOTS.Loaded)
            {
                Mod sots = InfernalCrossmod.SOTS.Mod;

                Type voidConsumable = sots.Code.GetType("SOTS.Items.Void.VoidConsumable");
                MethodInfo orig = voidConsumable.GetMethod("RefillEffect", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                voidSicknessDebuffDetour = new Hook(orig, RefillEffectDetour);
            }
        }

        public override void OnModUnload()
        {
            voidSicknessDebuffDetour?.Dispose();
        }

        private static void RefillEffectDetour(Action<VoidConsumable, Player, int> orig, VoidConsumable self, Player player, int amt)
        {
            orig(self, player, amt);

            player.AddBuff(ModContent.BuffType<VoidSickness2>(), 300);
        }
    }
}
