using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.NPCs.Perforator;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.NPCs.SlimeGod;
using Microsoft.Xna.Framework;
using ThoriumMod.Buffs;

namespace InfernalEclipseAPI.Common.GlobalNPCs
{
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumBossImmunites : GlobalNPC
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
    }
}
