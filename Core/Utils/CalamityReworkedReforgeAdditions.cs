using CalamityMod;
using InfernalEclipseAPI.Core.Systems;
using SOTS.Void;
using Terraria.DataStructures;
using Terraria.Utilities;
using ThoriumMod;

namespace InfernalEclipseAPI.Core.Utils
{
    public class CrossModCalReforgeRework : GlobalItem
    {
        public override void OnCreated(Item item, ItemCreationContext context)
        {
            storedPrefix = -1;
        }

        private static int storedPrefix = -1;

        public override void PreReforge(Item item)
        {
            storedPrefix = item.prefix;
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (!CalamityServerConfig.Instance.RemoveReforgeRNG || Main.gameMenu || storedPrefix == -1) return -1;

            int prefix;

            if (InfernalCrossmod.SOTS.Loaded)
            {
                prefix = CalamityVoidClassReforgeRework.ChooseSOTSPrefix(item, rand, storedPrefix);
                if (prefix != -1) return prefix;
            }

            if (InfernalCrossmod.Thorium.Loaded)
            {
                if (InfernalCrossmod.SOTSBardHealer.Loaded)
                {
                    prefix = CalamitySOTSThoriumVoidHybridClassReforgeRework.ChooseSOTSPrefix(item, rand, storedPrefix);
                    if (prefix != -1) return prefix;
                }

                prefix = CalamityThoriumClassReforgeRework.ChooseThoriumPrefix(item, rand, storedPrefix);
                if (prefix != -1) return prefix;
            }

            return -1;
        }

        public override void PostReforge(Item item)
        {
            storedPrefix = -1;
        }
    }

    [ExtendsFromMod("ThoriumMod")]
    public static class CalamityThoriumClassReforgeRework
    {
        public static int ChooseThoriumPrefix(Item item, UnifiedRandom rand, int storedPrefix)
        {
            if (!item.CountsAsClass<HealerDamage>() && !item.CountsAsClass<HealerTool>() && !item.CountsAsClass<HealerToolDamageHybrid>() && !item.CountsAsClass<BardDamage>()) return -1;

            return ThoriumItemUtils.GetReworkedReforge(item, rand, storedPrefix);
        }
    }

    [ExtendsFromMod("SOTS")]
    public static class CalamityVoidClassReforgeRework
    {
        public static int ChooseSOTSPrefix(Item item, UnifiedRandom rand, int storedPrefix)
        {
            if (!item.CountsAsClass<VoidGeneric>()) return -1;

            return -1;
        }
    }

    [ExtendsFromMod("SOTSBardHealer")]
    public static class CalamitySOTSThoriumVoidHybridClassReforgeRework
    {
        public static int ChooseSOTSPrefix(Item item, UnifiedRandom rand, int storedPrefix)
        {
            if (!item.CountsAsClass<VoidGeneric>() && !item.CountsAsClass<HealerDamage>() && !item.CountsAsClass<HealerTool>() && !item.CountsAsClass<HealerToolDamageHybrid>() && !item.CountsAsClass<BardDamage>()) return -1;

            return -1;
        }
    }
}
