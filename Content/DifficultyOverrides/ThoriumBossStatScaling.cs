using InfernumSaveSystem = InfernumMode.Core.GlobalInstances.Systems.WorldSaveSystem;
using System.Reflection;
using Terraria.DataStructures;
using ThoriumMod.NPCs.BossBoreanStrider;
using ThoriumMod.NPCs.BossThePrimordials;
using ThoriumMod.Projectiles.Boss;
using System.Linq;
using InfernalEclipseAPI.Core.Systems;
using ThoriumRework.Projectiles;
using InfernalEclipseAPI.Common.GlobalNPCs.NPCDebuffs;

namespace InfernalEclipseAPI.Content.DifficultyOverrides
{
    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumBossStatScaling : GlobalNPC
    {
        private static bool GetCalDifficulty(string diff)
        {
            return ModLoader.TryGetMod("CalamityMod", out Mod calamity) &&
                   calamity.Call("GetDifficultyActive", diff) is bool b && b;
        }

        private static bool IsInfernumActive()
        {
            return InfernumSaveSystem.InfernumModeEnabled;
        }

        private static bool GetFargoDifficullty(string diff)
        {
            if (!ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls))
            {
                return false;
            }

            return fargoSouls.Call(diff) is bool active && active;
        }
        private static bool IsWorldLegendary()
        {
            FieldInfo findInfo = typeof(Main).GetField("_currentGameModeInfo", BindingFlags.Static | BindingFlags.NonPublic);
            GameModeData data = (GameModeData)findInfo.GetValue(null);
            return (Main.getGoodWorld && data.IsMasterMode);
        }

        public static readonly int[] thorBossMinionTypes =
        [
            ModContent.NPCType<ThoriumMod.NPCs.BossThePrimordials.AquaiusBubble>(),
            ModContent.NPCType<ThoriumMod.NPCs.BossThePrimordials.ImpendingDread>(),
            ModContent.NPCType<UnstableAnger>(),
            ModContent.NPCType<InnerDespair>(),
            ModContent.NPCType<LucidBubble>(),
        ];

        public static bool IsReworkNPC(NPC npc)
        {
            if (!InfernalCrossmod.ThoriumRework.Loaded) return false;

            return ThoriumReworkEntities.IsReworkedThoriumMinion(npc);
        }

        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return (npc.boss || thorBossMinionTypes.Contains(npc.type) || IsReworkNPC(npc)) && (npc.ModNPC?.Mod?.Name == "ThoriumMod" || npc.ModNPC?.Mod?.Name == "ThoriumRework");
        }

        public override void SetDefaults(NPC entity)
        {
            if (IsInfernumActive()) 
            {
                if (entity.type == ModContent.NPCType<BoreanStrider>())
                {
                    entity.defense += 10;
                }
                if (entity.type == ModContent.NPCType<BoreanStriderPopped>())
                {
                    entity.defense += 5;
                }
            }

            if (InfernalCrossmod.SOTS.Loaded && entity.type == ModContent.NPCType<DreamEater>())
            {
                entity.GetGlobalNPC<VoidDamageNPC>().canDoVoidDamage = true;
                entity.GetGlobalNPC<VoidDamageNPC>().strongVoidDamge = true;
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(NPC npc, int numPlayers, float balance, float bossAdjustment)
        {
            //Boss Rush, 
            if (GetCalDifficulty("bossrush"))
            {
                string name = npc.ModNPC?.Name ?? "";

                //do this 
                if (name.Contains("BoreanStrider"))
                    npc.lifeMax *= 65;

                //ignore the rest if Thorium Bosses Reworked is active as this is already done in that mod.
                if (!ModLoader.TryGetMod("ThoriumRework", out _))
                {
                    if (name.Contains("TheGrandThunderBird"))
                        npc.lifeMax *= 125;
                    else if (name.Contains("QueenJellyfish"))
                        npc.lifeMax *= 115;
                    else if (name.Contains("Viscount"))
                        npc.lifeMax *= 110;
                    else if (name.Contains("StarScouter"))
                        npc.lifeMax *= 105;
                    else if (name.Contains("BuriedChampion") || name.Contains("GraniteEnergyStorm"))
                        npc.lifeMax *= 75;
                    else if (name.Contains("FallenBeholder"))
                        npc.lifeMax *= 65;
                    else if (name.Contains("Lich"))
                        npc.lifeMax *= 30;
                    else if (name.Contains("ForgottenOne"))
                        npc.lifeMax *= 15;
                    else if (name.Contains("SlagFury") || name.Contains("Aquaius") || name.Contains("Omnicide") || name.Contains("DreamEater"))
                        npc.lifeMax *= 2;
                }
            }

            if (IsWorldLegendary())
            {
                npc.lifeMax += (int)(0.1 * npc.lifeMax);
            }
            if (IsInfernumActive() || GetFargoDifficullty("MasochistMode"))
            {
                if (npc.ModNPC?.Name?.Contains("GraniteEnergyStorm") == true || npc.ModNPC?.Name?.Contains("BuriedChampion") == true)
                {
                    npc.lifeMax += (int)npc.lifeMax;
                }
                if (npc.ModNPC?.Name?.Contains("StarScouter") == true || npc.type == ModContent.NPCType<BoreanStrider>() || npc.type == ModContent.NPCType<BoreanStriderPopped>())
                {
                    npc.lifeMax += (int)(0.75 * npc.lifeMax);
                }
                string name = npc.ModNPC?.Name ?? "";
                if (name.Contains("SlagFury") || name.Contains("Aquaius") || name.Contains("Omnicide") || name.Contains("DreamEater"))
                    npc.lifeMax += (int)(0.15 * npc.lifeMax);

                npc.lifeMax += (int)(0.35 * npc.lifeMax);
            }
            else
            {
                if (GetFargoDifficullty("EternityMode"))
                {
                    if (npc.ModNPC?.Name?.Contains("GraniteEnergyStorm") == true || npc.ModNPC?.Name?.Contains("BuriedChampion") == true)
                    {
                        npc.lifeMax += (int)(0.75 * npc.lifeMax);
                    }
                    if (npc.ModNPC?.Name?.Contains("StarScouter") == true || npc.type == ModContent.NPCType<BoreanStrider>() || npc.type == ModContent.NPCType<BoreanStriderPopped>())
                    {
                        npc.lifeMax += (int)(0.5 * npc.lifeMax);
                    }

                    npc.lifeMax += (int)(0.25 * npc.lifeMax);
                }
                else if (GetCalDifficulty("death"))
                {
                    if (npc.ModNPC?.Name?.Contains("GraniteEnergyStorm") == true || npc.ModNPC?.Name?.Contains("BuriedChampion") == true)
                    {
                        npc.lifeMax += (int)(0.5 * npc.lifeMax);
                    }
                    if (npc.ModNPC?.Name?.Contains("StarScouter") == true || npc.type == ModContent.NPCType<BoreanStrider>() || npc.type == ModContent.NPCType<BoreanStriderPopped>())
                    {
                        npc.lifeMax += (int)(0.375 * npc.lifeMax);
                    }

                    npc.lifeMax += (int)(0.2 * npc.lifeMax);
                }
                else if (GetCalDifficulty("revengeance"))
                {
                    if (npc.ModNPC?.Name?.Contains("GraniteEnergyStorm") == true || npc.ModNPC?.Name?.Contains("BuriedChampion") == true)
                    {
                        npc.lifeMax += (int)(0.25 * npc.lifeMax);
                    }
                    if (npc.ModNPC?.Name?.Contains("StarScouter") == true || npc.type == ModContent.NPCType<BoreanStrider>() || npc.type == ModContent.NPCType<BoreanStriderPopped>())
                    {
                        npc.lifeMax += (int)(0.1875 * npc.lifeMax);
                    }

                    npc.lifeMax += (int)(0.1 * npc.lifeMax);
                }
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers)
        {
            string name = npc.ModNPC?.Name ?? "";
            float damageMod = 0;

            if (name.Contains("SlagFury") || name.Contains("Aquaius") || name.Contains("Omnicide") || name.Contains("DreamEater"))
                damageMod += 0.6f;

            if (IsWorldLegendary())
            {
                damageMod += 1.1f;
            }
            if (IsInfernumActive() || GetFargoDifficullty("MasochistMode"))
            {
                damageMod += 1.35f;
            }
            else
            {
                if (GetFargoDifficullty("EternityMode"))
                {
                    damageMod += 1.25f;
                }
                else if (GetCalDifficulty("death"))
                {
                    damageMod += 1.1f;
                }
            }

            modifiers.SourceDamage *= damageMod;
        }

        public override void PostAI(NPC npc)
        {
            //messing with the borean striders speed causes it to phase through the ground.
            if (npc.ModNPC?.Name?.Contains("BoreanStrider") == true || npc.ModNPC?.Name?.Contains("FallenBeholder") == true)
            {
                return;
            }

            if (IsWorldLegendary())
            {
                npc.position += npc.velocity * 0.5f;
            }
            if (IsInfernumActive() || GetFargoDifficullty("MasochistMode"))
            {
                npc.position += npc.velocity * 0.20f;
            }
            else
            {
                if (GetFargoDifficullty("EternityMode"))
                {
                    npc.position += npc.velocity * 0.10f;
                }
                else if (GetCalDifficulty("death"))
                {
                    npc.position += npc.velocity * 0.05f;
                }
            }
        }
    }

    [JITWhenModsEnabled("ThoriumRework")]
    [ExtendsFromMod("ThoriumRework")]
    public static class ThoriumReworkEntities
    {
        public static bool IsReworkedThoriumMinion(NPC npc)
        {
            return false;

            int[] reworkType =
            [
            ];

            if (reworkType.Contains(npc.type))
                return true;

            return false;
        }

        public static bool IsReworkedThoriumProjectile(Projectile projectile)
        {
            int[] reworkType =
            [
                ModContent.ProjectileType<ThoriumRework.Projectiles.ImpendingDread>(),
                ModContent.ProjectileType<ImpendingDreadF>(),
                ModContent.ProjectileType<ThoriumRework.Projectiles.LucidRay>(),
                ModContent.ProjectileType<LucidNuke>(),
                ModContent.ProjectileType<ThoriumRework.Projectiles.AquaiusBubble>(),
                ModContent.ProjectileType<AquaiusPunchAttack>(),
                ModContent.ProjectileType<DeathRain>(),
                ModContent.ProjectileType<InfernalRay>()
            ];

            if (reworkType.Contains(projectile.type))
                return true;

            return false;
        }
    }


    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumBossProjStatScaling : GlobalProjectile
    {
        public static bool IsReworkNPC(Projectile projectile)
        {
            if (!InfernalCrossmod.ThoriumRework.Loaded) return false;

            return ThoriumReworkEntities.IsReworkedThoriumProjectile(projectile);
        }

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            int[] types =
            [
                ModContent.ProjectileType<AquaSplash>(),
                ModContent.ProjectileType<AquaTyphoon>(),
                ModContent.ProjectileType<LucidFury>(),
                ModContent.ProjectileType<LucidMiasma>(),
                ModContent.ProjectileType<LucidPulse>(),
                ModContent.ProjectileType<LucidTyphoon>(),
                ModContent.ProjectileType<FlameFury>(),
                ModContent.ProjectileType<FlameLash>(),
                ModContent.ProjectileType<FlameNova>(),
                ModContent.ProjectileType<FlamePulsePro>(),
                ModContent.ProjectileType<AquaBomb2>(),
                ModContent.ProjectileType<LucidBomb2>(),
                ModContent.ProjectileType<ThoriumMod.Projectiles.Boss.LucidRay>(),
                ModContent.ProjectileType<DeathRaySpawn3>(),
                ModContent.ProjectileType<DeathCircle2>(),
                ModContent.ProjectileType<DeathRay>()
            ];

            return types.Contains(entity.type) || IsReworkNPC(entity);
        }

        private static bool GetCalDifficulty(string diff)
        {
            return ModLoader.TryGetMod("CalamityMod", out Mod calamity) &&
                   calamity.Call("GetDifficultyActive", diff) is bool b && b;
        }

        private static bool IsInfernumActive()
        {
            return InfernumSaveSystem.InfernumModeEnabled;
        }

        private static bool GetFargoDifficullty(string diff)
        {
            if (!ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls))
            {
                return false;
            }

            return fargoSouls.Call(diff) is bool active && active;
        }
        private static bool IsWorldLegendary()
        {
            FieldInfo findInfo = typeof(Main).GetField("_currentGameModeInfo", BindingFlags.Static | BindingFlags.NonPublic);
            GameModeData data = (GameModeData)findInfo.GetValue(null);
            return (Main.getGoodWorld && data.IsMasterMode);
        }

        public override void SetDefaults(Projectile entity)
        {
            if (InfernalCrossmod.SOTS.Loaded && entity.ModProjectile.Name.Contains("Lucid"))
            {
                entity.GetGlobalProjectile<VoidDamageProjectile>().canDoVoidDamage = true;
                entity.GetGlobalProjectile<VoidDamageProjectile>().strongVoidDamge = true;
            }
        }

        public override void ModifyHitPlayer(Projectile projectile, Player target, ref Player.HurtModifiers modifiers)
        {
            float damageMod = 0;

            if (IsWorldLegendary())
            {
                damageMod += 1.35f;
            }
            if (IsInfernumActive() || GetFargoDifficullty("MasochistMode"))
            {
                damageMod += 2.2f;
            }
            else
            {
                if (GetFargoDifficullty("EternityMode"))
                {
                    damageMod += 1.675f;
                }
                else if (GetCalDifficulty("death"))
                {
                    damageMod += 1.5f;
                }
            }

            modifiers.SourceDamage *= damageMod;
        }
    }
}