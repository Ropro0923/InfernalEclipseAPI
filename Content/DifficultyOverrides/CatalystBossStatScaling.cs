using InfernumActive = InfernalEclipseAPI.Content.DifficultyOverrides.hellActive;

namespace InfernalEclipseAPI.Content.DifficultyOverrides
{
    public class CatalystBossStatScaling : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            return npc.boss && ((ModType)npc.ModNPC)?.Mod.Name == "CatalystMod";
        }

        public override void ApplyDifficultyAndPlayerScaling(NPC npc, int numPlayers, float balance, float bossAdjustment)
        {
            Mod mod;
            bool flag = false;
            int num1 = 0, num2 = 0;

            if (ModLoader.TryGetMod("CalamityMod", out mod))
            {
                object result = mod.Call("GetDifficultyActive", "BossRush");
                if (result is bool b)
                {
                    flag = b;
                    num1 = 1;
                }
            }
            num2 = flag ? 1 : 0;
            if ((num1 & num2) != 0)
            {
                ModNPC modNPC14 = npc.ModNPC;
                if ((modNPC14 != null ? (modNPC14.Name.Contains("Astrageldon") ? 1 : 0) : 0) != 0)
                {
                    npc.lifeMax *= 10;
                }
            }
            else
            {
                if (NPC.downedMoonlord)
                {
                    npc.lifeMax += (int)(((double).35) * (double)npc.lifeMax);
                }
            }

            if (InfernumActive.InfernumActive && !ModLoader.TryGetMod("CnI", out _))
            {
                npc.lifeMax += (int)(((double).35) * (double)npc.lifeMax);
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers)
        {
            if (NPC.downedMoonlord)
            {
                modifiers.SourceDamage *= 1.35f;
            }
            
            if (InfernumActive.InfernumActive && !ModLoader.TryGetMod("CnI", out _))
            {
                modifiers.SourceDamage *= 1.35f;
            }
        }
    }
}