using InfernalEclipseAPI.Core.World;
using CalamityMod.NPCs.BrimstoneElemental;
using CalamityMod.NPCs.AquaticScourge;
using CalamityMod.NPCs.Yharon;
using InfernalEclipseAPI.Content.Items.Placeables.Paintings;
using CalamityMod.Items.Placeables.Furniture.DevPaintings;
using Terraria.GameContent.ItemDropRules;
using InfernalEclipseAPI.Core.Systems;
using System.Collections.Generic;
using InfernumMode.Core.GlobalInstances.Systems;
using CalamityMod.World;
using CalamityMod.NPCs.Crags;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod;
using System.Linq;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.Items;
using CalamityMod.Items.Weapons.Typeless;
using CalamityMod.Items.Accessories;

namespace InfernalEclipseAPI.Common.GlobalNPCs
{
    public class InfernalGlobalNPC : GlobalNPC
    {
        public override void SetDefaults(NPC entity)
        {
            if (InfernalCrossmod.Thorium.Loaded)
            {
                if (entity.buffImmune[BuffID.Confused] && entity.boss)
                {
                    entity.buffImmune[InfernalCrossmod.Thorium.Mod.Find<ModBuff>("Stunned").Type] = true;
                }
            }

            switch (entity.type)
            {
                case NPCID.DetonatingBubble:
                    if (WorldSaveSystem.InfernumModeEnabled && Main.masterMode && CalamityWorld.revenge && NPC.AnyNPCs(NPCID.DukeFishron))
                        entity.dontTakeDamage = false;
                    break;
                default:
                    break;
            }
        }

        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.TheDestroyer)
            {
                InfernalWorld.dreadonDestroyerDialoguePlayed = false;
                InfernalWorld.dreadonDestroyer2DialoguePlayed = false;
            }
            if (npc.type == NPCID.Plantera)
            {
                InfernalWorld.jungleSubshockPlanteraDialoguePlayed = false;
                InfernalWorld.jungleSlagspitterPlateraDiaglougePlayer = false;
            }
            if (npc.type == ModContent.NPCType<BrimstoneElemental>() || npc.type == ModContent.NPCType<AquaticScourgeHead>())
            {
                InfernalWorld.sulfurScourgeDialoguePlayed = false;
                InfernalWorld.brimstoneDialoguePlayed = false;
            }
            if (npc.type == ModContent.NPCType<Yharon>())
            {
                InfernalWorld.yharonDischarge = false;
                InfernalWorld.yharonSmasher = false;
            }
        }

        private sealed class EvilBossDownedCondition : IItemDropRuleCondition
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.downedBoss2;
            public bool CanShowItemDropInUI() => true;
            public string GetConditionDescription() => "Downed Evil Boss";
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.boss) //anything that is considered a boss will have a 1/100 chance to drop our dev painting directly
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfernalTwilight>(), ThankYouPainting.DropInt));
            }

            if (npc.type == ModContent.NPCType<SoulSlurper>() && InfernalConfig.Instance.BossKillCheckOnOres)
            {
                int slurperPole = ModContent.ItemType<SlurperPole>();

                npcLoot.RemoveWhere(rule =>
                    rule is CommonDrop cd && cd.itemId == slurperPole ||
                    rule is ItemDropWithConditionRule iwc && iwc.itemId == slurperPole);

                foreach (var rule in npcLoot.Get())
                    PruneFromChains(rule, slurperPole);

                npcLoot.Add(ItemDropRule.ByCondition(new EvilBossDownedCondition(), slurperPole, 30));
            }

            if (InfernalConfig.Instance.CalamityExpertAccessories) 
            {
                if (npc.type == ModContent.NPCType<ProfanedGuardianHealer>())
                    npcLoot.RemoveWhere(Relic1 => Relic1 is CommonDrop commonDrop1 && commonDrop1.itemId == ModContent.ItemType<RelicOfConvergence>(), true);
                if (npc.type == ModContent.NPCType<ProfanedGuardianDefender>())
                    npcLoot.RemoveWhere(Relic2 => Relic2 is CommonDrop commonDrop2 && commonDrop2.itemId == ModContent.ItemType<RelicOfResilience>(), true);
                if (npc.type == ModContent.NPCType<ProfanedGuardianCommander>())
                {
                    npcLoot.RemoveWhere(Relic3 => Relic3 is CommonDrop commonDrop3 && commonDrop3.itemId == ModContent.ItemType<RelicOfDeliverance>(), true);
                    npcLoot.RemoveWhere(Banner3 => Banner3 is CommonDrop commonDrop4 && commonDrop4.itemId == ModContent.ItemType<WarbanneroftheSun>(), true);
                    DropHelper.Add(DropHelper.DefineConditionalDropSet((ILoot)(object)npcLoot, DropHelper.RevAndMaster), ModContent.ItemType<WarbanneroftheSun>(), 10, 1, 1, false);
                    npcLoot.Add(new OneFromOptionsDropRule(1, 3, [ ModContent.ItemType<RelicOfConvergence>(), ModContent.ItemType<RelicOfDeliverance>(), ModContent.ItemType<RelicOfResilience>() ]));
                }
            }
        }

        private static void PruneFromChains(IItemDropRule rule, int itemId)
        {
            if (rule.ChainedRules is null || rule.ChainedRules.Count == 0)
                return;

            rule.ChainedRules.RemoveAll(c =>
                c.RuleToChain is CommonDrop cd && cd.itemId == itemId ||
                c.RuleToChain is ItemDropWithConditionRule iwc && iwc.itemId == itemId);

            foreach (var chain in rule.ChainedRules.ToList())
                PruneFromChains(chain.RuleToChain, itemId);
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.Player;
            if (InfernalCrossmod.SOTS.Loaded)
            {
                if (player.ZoneHallow && Main.hardMode && !TwoMechsDowned())
                {
                    pool.Remove(InfernalCrossmod.SOTS.Mod.Find<ModNPC>("HallowTreasureSlime").Type);
                }
            }
        }

        public static bool TwoMechsDowned()
        {
            return (NPC.downedMechBoss1 && NPC.downedMechBoss2) || (NPC.downedMechBoss1 && NPC.downedMechBoss3) || (NPC.downedMechBoss2 && NPC.downedMechBoss3);
        }

        public override bool CheckDead(NPC npc)
        {
            if (npc.type == NPCID.TheDestroyer)
            {
                InfernalWorld.dreadonDestroyerDialoguePlayed = false;
                InfernalWorld.dreadonDestroyer2DialoguePlayed = false;
            }
            if (npc.type == NPCID.Plantera)
            {
                InfernalWorld.jungleSubshockPlanteraDialoguePlayed = false;
                InfernalWorld.jungleSlagspitterPlateraDiaglougePlayer = false;
            }
            if (npc.type == ModContent.NPCType<BrimstoneElemental>() || npc.type == ModContent.NPCType<AquaticScourgeHead>())
            {
                InfernalWorld.sulfurScourgeDialoguePlayed = false;
                InfernalWorld.brimstoneDialoguePlayed = false;
            }

            return base.CheckDead(npc);
        }
        public override bool InstancePerEntity => true;
    }
}
