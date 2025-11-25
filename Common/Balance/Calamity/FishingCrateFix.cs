using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CalamityMod;
using Terraria.GameContent.ItemDropRules;

namespace InfernalEclipseAPI.Common.Balance.Calamity
{
    public class FishingCrateFix : GlobalItem
    {
        //IDK why nothing is working :(
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }

        private static readonly HashSet<int> OreAndBarIds = new()
        {
            // Ores
            364,   // Cobalt Ore
            1104,  // Palladium Ore
            365,   // Mythril Ore
            1105,  // Orichalcum Ore
            366,   // Adamantite Ore
            1106,  // Titanium Ore

            // Bars
            381,   // Cobalt Bar
            1184,  // Palladium Bar
            382,   // Mythril Bar
            1191,  // Orichalcum Bar
            391,   // Adamantite Bar
            1198,  // Titanium Bar
        };

        public override void ModifyItemLoot(Item item, ItemLoot loot)
        {
            bool isWoodenHard = item.type == ItemID.WoodenCrateHard;
            bool isIronHard = item.type == ItemID.IronCrateHard;
            bool isBiomeOrGoldenHard =
                item.type == ItemID.CorruptFishingCrateHard ||
                item.type == ItemID.CrimsonFishingCrateHard ||
                item.type == ItemID.HallowedFishingCrateHard ||
                item.type == ItemID.DungeonFishingCrateHard ||
                item.type == ItemID.JungleFishingCrateHard ||
                item.type == ItemID.FloatingIslandFishingCrateHard ||
                item.type == ItemID.LavaCrateHard ||
                item.type == ItemID.OceanCrateHard ||
                item.type == ItemID.OasisCrateHard ||
                item.type == ItemID.FrozenCrateHard ||
                item.type == ItemID.GoldenCrateHard;

            if (!isWoodenHard && !isIronHard && !isBiomeOrGoldenHard)
                return;

            // Strip vanilla HM ores/bars from these crates
            RemoveCrateHardmodeOresAndBars(loot);

            // Add our own rules, with proper non-null conditions
            var hardmodeCond = new HardmodeCondition();
            var mechAnyCond = new MechAnyCondition();
            var mechsAllCond = new MechsAllCondition();

            if (isWoodenHard)
            {
                // WOODEN HARD CRATE

                // Ores – just hardmode gated
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 364, 7, 4, 15));   // Cobalt Ore
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 1104, 7, 4, 15));  // Palladium Ore

                // Bars – ONE-OF-MANY gated by Hardmode
                var hmBars = new LeadingConditionRule(hardmodeCond);
                hmBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    5,
                    381,   // Cobalt Bar
                    1184   // Palladium Bar
                ));
                loot.Add(hmBars);
            }
            else if (isIronHard)
            {
                // Base cobalt/palladium ore (HM)
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 364, 8, 12, 21));   // Cobalt
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 1104, 8, 12, 21));  // Palladium

                // Mythril/Orichalcum ore (any mech)
                loot.Add(ItemDropRule.ByCondition(mechAnyCond, 365, 10, 25, 34));   // Mythril
                loot.Add(ItemDropRule.ByCondition(mechAnyCond, 1105, 10, 25, 34));  // Orichalcum

                // Titanium/Adamantite ore (all mechs)
                loot.Add(ItemDropRule.ByCondition(mechsAllCond, 1106, 10, 25, 34)); // Titanium
                loot.Add(ItemDropRule.ByCondition(mechsAllCond, 366, 10, 25, 34));  // Adamantite

                // Bars: one-of-many chains

                // Base Cobalt/Palladium bars (HM)
                var hmBars = new LeadingConditionRule(hardmodeCond);
                hmBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    14,
                    381,   // Cobalt
                    1184   // Palladium
                ));
                loot.Add(hmBars);

                // Extra Cobalt/Palladium roll after ANY mech
                var mechBarsBase = new LeadingConditionRule(mechAnyCond);
                mechBarsBase.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    14,
                    381,
                    1184
                ));
                loot.Add(mechBarsBase);

                // Mythril/Orichalcum bars after ANY mech
                var mechBars = new LeadingConditionRule(mechAnyCond);
                mechBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    18,
                    382,   // Mythril
                    1191   // Orichalcum
                ));
                loot.Add(mechBars);

                // Titanium/Adamantite bars after ALL mechs
                var allMechBars = new LeadingConditionRule(mechsAllCond);
                allMechBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    18,
                    1198,  // Titanium
                    391    // Adamantite
                ));
                loot.Add(allMechBars);
            }
            else if (isBiomeOrGoldenHard)
            {
                // Ores – big stacks
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 364, 7, 35, 45));   // Cobalt
                loot.Add(ItemDropRule.ByCondition(hardmodeCond, 1104, 7, 35, 45));  // Palladium

                loot.Add(ItemDropRule.ByCondition(mechAnyCond, 365, 7, 35, 45));    // Mythril
                loot.Add(ItemDropRule.ByCondition(mechAnyCond, 1105, 7, 35, 45));   // Orichalcum

                loot.Add(ItemDropRule.ByCondition(mechsAllCond, 1106, 7, 35, 45));  // Titanium
                loot.Add(ItemDropRule.ByCondition(mechsAllCond, 366, 7, 35, 45));   // Adamantite

                // Bars – one-of-many by tier

                // Base Cobalt/Palladium bars (HM)
                var hmBars = new LeadingConditionRule(hardmodeCond);
                hmBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    17,
                    381,
                    1184
                ));
                loot.Add(hmBars);

                // Mythril/Orichalcum bars after ANY mech
                var mechBars = new LeadingConditionRule(mechAnyCond);
                mechBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    17,
                    382,
                    1191
                ));
                loot.Add(mechBars);

                // Titanium/Adamantite bars after ALL mechs
                var allMechBars = new LeadingConditionRule(mechsAllCond);
                allMechBars.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(
                    17,
                    1198,
                    391
                ));
                loot.Add(allMechBars);
            }
        }

        private static void RemoveCrateHardmodeOresAndBars(ItemLoot loot)
        {
            loot.RemoveWhere(rule =>
            {
                // Rules with a direct itemId field (CommonDrop, NotScalingWithLuck, etc)
                var type = rule.GetType();
                FieldInfo itemIdField = type.GetField("itemId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (itemIdField != null)
                {
                    int id = (int)itemIdField.GetValue(rule);
                    if (OreAndBarIds.Contains(id))
                        return true;
                }

                // One-from-options rules
                if (rule is OneFromOptionsDropRule one && one.dropIds.Any(id => OreAndBarIds.Contains(id)))
                    return true;

                return false;
            }, includeGlobalDrops: true);
        }
    }

    public class HardmodeCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info) => Main.hardMode;
        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => string.Empty;
    }

    public class MechAnyCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info) => NPC.downedMechBossAny;
        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => string.Empty;
    }

    public class MechsAllCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info) =>
            NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3;

        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => string.Empty;
    }
}
