using CalamityMod.Items.Weapons.Melee;
using InfernalEclipseAPI.Core.Systems;
using ThoriumMod;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.BossForgottenOne;
using ThoriumMod.Items.Bronze;
using ThoriumMod.Items.Cultist;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;
using static Terraria.ModLoader.ModContent;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled(InfernalCrossmod.Thorium.Name)]
    [ExtendsFromMod("ThoriumMod")]
    public class ThoriumGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (InfernalConfig.Instance.ChanageWeaponClasses) 
            {
                if (item.type == ItemID.TheAxe)
                {
                    item.DamageType = ThoriumDamageBase<BardDamage>.Instance;
                }

                if (item.type == ItemType<AncientFlame>())
                {
                    item.DamageType = ThoriumDamageBase<HealerDamage>.Instance;
                    item.damage = 32;
                }

                if (item.type == ItemType<TheBurningSky>())
                {
                    item.DamageType = ThoriumDamageBase<HealerDamage>.Instance;
                    item.mana = 35;
                }
            }

            if (InfernalConfig.Instance.ThoriumBalanceChangess)
            {
                if (item.type == ItemType<ShadeMasterMask>())
                {
                    item.defense = 10;
                }
                if (item.type == ItemType<ShadeMasterTreads>())
                {
                    item.defense = 12;
                }
                if (item.type == ItemType<ShadeMasterGarb>())
                {
                    item.defense = 16;
                }

                if (item.type == ItemType<IridescentHelmet>())
                {
                    item.defense = 5;
                }
                if (item.type == ItemType<IridescentMail>())
                {
                    item.defense = 6;
                }

                if (item.type == ItemType<FallenPaladinFaceguard>())
                {
                    item.defense = 20;
                }
                if (item.type == ItemType<FallenPaladinCuirass>())
                {
                    item.defense = 28;
                }
                if (item.type == ItemType<FallenPaladinGreaves>())
                {
                    item.defense = 22;
                }

                if (item.type == ItemType<WhisperingHood>())
                {
                    item.defense = 10;
                }
                if (item.type == ItemType<WhisperingTabard>())
                {
                    item.defense = 20;
                }
                if (item.type == ItemType<WhisperingLeggings>())
                {
                    item.defense = 14;
                }
            }
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (InfernalConfig.Instance.ThoriumBalanceChangess)
            {
                if (item.type == ItemType<CrystalHoney>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.05f;
                }

                if (item.type == ItemType<DemonTongue>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.02f;
                }

                if (item.type == ItemType<DarkGlaze>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.05f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 5f;
                }

                if (item.type == ItemType<ArchDemonCurse>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.08f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 7f;
                }

                if (item.type == ItemType<FlightMask>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.03f;
                    player.GetCritChance(DamageClass.Throwing) -= 1f;
                }

                if (item.type == ItemType<FlightMail>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.07f;
                }

                if (item.type == ItemType<BronzeHelmet>())
                {
                    player.GetCritChance(DamageClass.Throwing) -= 4f;
                }
                if (item.type == ItemType<BronzeBreastplate>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.1f;
                }

                if (item.type == ItemType<PlagueDoctorsMask>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.07f;
                }
                if (item.type == ItemType<PlagueDoctorsGarb>())
                {
                    player.GetDamage(DamageClass.Throwing) += 0.01f;
                }
                if (item.type == ItemType<PlagueDoctorsLeggings>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.04f;
                }

                if (item.type == ItemType<FungusHat>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.03f;
                }
                if (item.type == ItemType<FungusGuard>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.02f;
                }

                if (item.type == ItemType<ShadeMasterMask>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.05f;
                }
                if (item.type == ItemType<ShadeMasterTreads>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.025f;
                }

                if (item.type == ItemType<WhiteDwarfMask>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.1f;
                }
                if (item.type == ItemType<WhiteDwarfGreaves>())
                {
                    player.GetDamage(DamageClass.Throwing) -= 0.05f;
                }

                if (item.type == ItemType<IridescentHelmet>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.11f;
                }
                if (item.type == ItemType<IridescentMail>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.02f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 6f;
                }
                if (item.type == ItemType<IridescentGreaves>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.05f;
                }

                if (item.type == ItemType<BloomingTabard>())
                {
                    InfernalCrossmod.Thorium.Mod.Call(new object[]
                    {
                        "BonusHealerHealBonus",
                        player,
                        +1
                    });
                }

                if (item.type == ItemType<WarlockHood>())
                {
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 5f;
                }
                if (item.type == ItemType<WarlockGarb>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                }
                if (item.type == ItemType<WarlockLeggings>())
                {
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 5f;
                }

                if (item.type == ItemType<BioTechGarment>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) += 0.1f;
                }

                if (item.type == ItemType<FallenPaladinFaceguard>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                }
                if (item.type == ItemType<FallenPaladinCuirass>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                }
                if (item.type == ItemType<FallenPaladinGreaves>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                }

                if (item.type == ItemType<WhisperingHood>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.1f;
                    player.GetDamage(DamageClass.Generic) += 0.05f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 2f;
                }
                if (item.type == ItemType<WhisperingTabard>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 2f;
                }
                if (item.type == ItemType<WhisperingLeggings>())
                {
                    player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.2f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 6f;
                }

                if (InfernalCrossmod.RagnarokMod.Loaded)
                {
                    if (item.type == ItemType<NinjaEmblem>())
                    {
                        player.GetDamage(DamageClass.Generic) -= 0.03f;
                        player.GetCritChance(DamageClass.Generic) -= 3f;
                    }
                }

                if (InfernalCrossmod.CalBardHealer.Loaded)
                {
                    Mod cBH = InfernalCrossmod.CalBardHealer.Mod;
                    int FindItem(string name) => cBH.Find<ModItem>(name).Type;

                    if (item.type == FindItem("TarragonParagonCrown"))
                    {
                        InfernalCrossmod.Thorium.Mod.Call(new object[]
                        {
                        "BonusHealerHealBonus",
                        player,
                        -2
                        });
                    }

                    if (item.type == FindItem("BloodflareRitualistMask"))
                    {
                        InfernalCrossmod.Thorium.Mod.Call(new object[]
                        {
                        "BonusHealerHealBonus",
                        player,
                        -4
                        });
                    }

                    if (item.type == FindItem("SilvaGuardianHelmet"))
                    {
                        InfernalCrossmod.Thorium.Mod.Call(new object[]
                        {
                        "BonusHealerHealBonus",
                        player,
                        -5
                        });
                    }

                    if (item.type == FindItem("AuricTeslaValkyrieVisage"))
                    {
                        InfernalCrossmod.Thorium.Mod.Call(new object[]
                        {
                        "BonusHealerHealBonus",
                        player,
                        -8
                        });
                    }
                    if (item.type == FindItem("AugmentedAuricTeslaValkyrieVisage"))
                    {
                        InfernalCrossmod.Thorium.Mod.Call(new object[]
                        {   
                        "BonusHealerHealBonus",
                        player,
                        -8
                        });
                    }

                    if (item.type == FindItem("ElementalBloom"))
                    {
                        player.GetDamage(ThoriumDamageBase<HealerDamage>.Instance) -= 0.05f;
                        player.GetCritChance(ThoriumDamageBase<HealerDamage>.Instance) -= 7f;
                    }
                }
            }
        }
    }
}
