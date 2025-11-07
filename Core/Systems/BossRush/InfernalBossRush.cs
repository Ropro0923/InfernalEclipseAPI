using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamityMod;
using CalamityMod.NPCs.NormalNPCs;
using InfernumMode.Content.BehaviorOverrides.BossAIs.KingSlime;
using static CalamityMod.Events.BossRushEvent;
using static Terraria.ModLoader.ModContent;

namespace InfernalEclipseAPI.Core.Systems.BossRush
{
    public class InfernalBossRush : ModSystem
    {
        public override void PostSetupContent()
        {
            Bosses = [];

            if (InfernalCrossmod.Thorium.Loaded)
            {
                Bosses.Add(new Boss(ThoriumNPC("TheGrandThunderBird"), spawnContext: type => { 
                    NPC.SpawnOnPlayer(ClosestPlayerToWorldCenter, type); 
                
                    if (!InfernalConfig.Instance.ForceFullXerocDialogue)
                        DownedBossSystem.startedBossRushAtLeastOnce = true;
                }, permittedNPCs: new int[]
                    { ThoriumNPC("StormHatchling"), ThoriumNPC("TheGrandThunderBird") }));
            }

            Bosses.Add(new Boss(NPCID.KingSlime, spawnContext: type => { NPC.SpawnOnPlayer(ClosestPlayerToWorldCenter, type); }, 
                permittedNPCs: new int[] { NPCID.BlueSlime, NPCID.YellowSlime, NPCID.PurpleSlime, NPCID.RedSlime, NPCID.GreenSlime, NPCID.RedSlime, NPCID.IceSlime, NPCID.UmbrellaSlime, NPCID.Pinky, NPCID.SlimeSpiked, NPCID.RainbowSlime,
                                            NPCType<KingSlimeJewelRuby>(), NPCType<KingSlimeJewelSapphire>(), NPCType<KingSlimeJewelEmerald>(), NPCType<Ninja>() }));

            if (InfernalCrossmod.Consolaria.Loaded)
            {
                Bosses.Add(new Boss(ConsolariaNPC("Lepus"), spawnContext: type => { NPC.SpawnOnPlayer(ClosestPlayerToWorldCenter, type); }, permittedNPCs: new int[] { ConsolariaNPC("DisasterBunny") }));
            }

            if (InfernalCrossmod.Thorium.Loaded)
            {
                
            }
        }

        public static int ThoriumNPC(string name)
        {
            return InfernalCrossmod.Thorium.Mod.Find<ModNPC>(name).Type;
        }

        public static int ConsolariaNPC(string name)
        {
            return InfernalCrossmod.Consolaria.Mod.Find<ModNPC>(name).Type;
        }
    }
}