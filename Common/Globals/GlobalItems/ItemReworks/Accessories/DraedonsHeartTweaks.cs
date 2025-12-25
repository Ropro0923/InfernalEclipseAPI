using System.Collections.Generic;
using System.Reflection;
using CalamityMod.Items.Accessories;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ItemReworks.Accessories
{
    public class DraedonsHeartTweaks : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ModContent.ItemType<DraedonsHeart>() && InfernalConfig.Instance.CalamityBalanceChanges;

        public override void SetDefaults(Item entity)
        {
            entity.defense = 24;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(item, tooltips);
        }
    }

    public class DraedonsHeartOverridesSystem : ModSystem
    {
        public override void Load()
        {
            if (!ModLoader.HasMod("CalamityMod") || !InfernalConfig.Instance.CalamityBalanceChanges)
                return;

            Assembly calamity = ModLoader.GetMod("CalamityMod").Code;

            PatchAllFieldReads(calamity,
                "CalamityMod.Items.Accessories.DraedonsHeart",
                "NanomachinesDuration",
                () => 150);

            PatchAllFieldReads(calamity,
                "CalamityMod.Items.Accessories.DraedonsHeart",
                "NanomachinesHealPerFrame",
                () => 2);

            PatchAllFieldReads(calamity,
                "CalamityMod.Items.Accessories.DraedonsHeart",
                "NanomachinePauseAfterDamage",
                () => 180);

            PatchAllFieldReads(calamity,
                "CalamityMod.Items.Accessories.DraedonsHeart",
                "NanomachinePauseAfterShieldDamage",
                () => 90);
        }

        private static void PatchAllFieldReads(Assembly asm, string declaringTypeFullName, string fieldName, Func<int> valueFactory)
        {
            Type declaringType = asm.GetType(declaringTypeFullName);
            if (declaringType == null)
                return;

            FieldInfo field = declaringType.GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic);
            if (field == null)
                return;

            int fieldToken = field.MetadataToken;

            foreach (Type t in asm.GetTypes())
                foreach (MethodInfo m in t.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (m.IsAbstract || m.GetMethodBody() == null)
                        continue;
                    if (m.ContainsGenericParameters || m.IsGenericMethodDefinition)
                        continue;

                    if (!MethodReadsField(m, fieldToken))
                        continue;

                    MonoModHooks.Modify(m, il =>
                    {
                        var c = new ILCursor(il);
                        while (c.TryGotoNext(MoveType.After, i => i.MatchLdsfld(field)))
                        {
                            c.Emit(OpCodes.Pop);
                            c.EmitDelegate(valueFactory);
                        }
                    });
                }

            InfernalEclipseAPI.Instance.Logger.Info($"[IEoR] {fieldName} adjusted successfully in {declaringTypeFullName}");
        }

        private static bool MethodReadsField(MethodInfo m, int fieldMetadataToken)
        {
            try
            {
                byte[] il = m.GetMethodBody()?.GetILAsByteArray();
                if (il == null || il.Length < 5)
                    return false;

                for (int i = 0; i <= il.Length - 5; i++)
                {
                    if (il[i] != 0x7E) // ldsfld
                        continue;

                    int token = il[i + 1] | (il[i + 2] << 8) | (il[i + 3] << 16) | (il[i + 4] << 24);
                    if (token == fieldMetadataToken)
                        return true;
                }
            }
            catch { }
            return false;
        }
    }
}
