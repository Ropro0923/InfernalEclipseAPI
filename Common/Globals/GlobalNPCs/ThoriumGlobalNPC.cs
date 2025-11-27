using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.NPCs.Perforator;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.NPCs.SlimeGod;
using InfernalEclipseAPI.Core.Systems;
using Microsoft.Xna.Framework;
using ThoriumMod.Buffs;
using ThoriumMod.Scenes;

namespace InfernalEclipseAPI.Common.GlobalNPCs
{
    [JITWhenModsEnabled(InfernalCrossmod.Thorium.Name)]
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumGlobalNPC : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            int oozed = ModContent.BuffType<Oozed>();
            int stunned = ModContent.BuffType<Stunned>();

            // Perforator worms
            if (npc.type == ModContent.NPCType<PerforatorHeadSmall>() ||
                npc.type == ModContent.NPCType<PerforatorBodySmall>() ||
                npc.type == ModContent.NPCType<PerforatorTailSmall>() ||

                npc.type == ModContent.NPCType<PerforatorHeadMedium>() ||
                npc.type == ModContent.NPCType<PerforatorBodyMedium>() ||
                npc.type == ModContent.NPCType<PerforatorTailMedium>() ||

                npc.type == ModContent.NPCType<PerforatorHeadLarge>() ||
                npc.type == ModContent.NPCType<PerforatorBodyLarge>() ||
                npc.type == ModContent.NPCType<PerforatorTailLarge>() ||

                // Slime God’s summoned slimes
                npc.type == ModContent.NPCType<CrimulanPaladin>() ||
                npc.type == ModContent.NPCType<EbonianPaladin>() ||

                npc.type == ModContent.NPCType<SplitCrimulanPaladin>() ||
                npc.type == ModContent.NPCType<SplitEbonianPaladin>() ||

                //Profaned Guardians
                npc.type == ModContent.NPCType<ProfanedGuardianCommander>() ||
                npc.type == ModContent.NPCType<ProfanedGuardianDefender>() ||
                npc.type == ModContent.NPCType<ProfanedGuardianHealer>()
                )
            {
                npc.buffImmune[oozed] = true;
                npc.buffImmune[stunned] = true;
            }
        }
<<<<<<<< HEAD:Common/Globals/GlobalNPCs/ThoriumBossImmunites.cs
========

        private static readonly HashSet<string> ThoriumBossNames = new()
{
            "TheGrandThunderBird",
            "QueenJellyfish",
            "Viscount",
            "GraniteEnergyStorm",
            "BuriedChampion",
            "StarScouter",
            "BoreanStrider",
            "FallenBeholder",
            "Lich",
            "LichHeadless",
            "ForgottenOne",
            "ForgottenOneCracked",
            "ForgottenOneReleased",
            "DreamEater",
            "Omnicide",
            "SlagFury",
            "Aquaius",
            "PatchWerk",
            "CorpseBloom",
            "Illusionist",
        };

        public override void PostAI(NPC npc)
        {
            if (!npc.active || !npc.boss || npc.ModNPC == null)
                return;

            if (npc.ModNPC.Mod.Name == "ThoriumMod" && ThoriumBossNames.Contains(npc.ModNPC.Name))
            {
                if (CalamityServerConfig.Instance.BossZen)
                {
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        Player player = Main.player[i];
                        if (!player.active || player.dead)
                            continue;

                        if (Vector2.Distance(player.Center, npc.Center) < 6400f)
                        {
                            // give at least 1 second to confirm it’s being applied
                            player.AddBuff(ModContent.BuffType<BossEffects>(), 60, true, false);
                        }
                    }
                }
            }
        }
>>>>>>>> master:Common/Globals/GlobalNPCs/ThoriumGlobalNPC.cs
    }
}
