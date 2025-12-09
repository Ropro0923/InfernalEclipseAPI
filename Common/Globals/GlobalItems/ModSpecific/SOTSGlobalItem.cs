using CalamityMod;
using CalamityMod.Items.Weapons.Melee;
using InfernalEclipseAPI.Core.Systems;
using SOTS;
using SOTS.Items.AbandonedVillage;
using SOTS.Items.ChestItems;
using SOTS.Items.Earth;
using SOTS.Items.Tide;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.BossForgottenOne;
using ThoriumMod.Items.Cultist;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod;
using SOTS.Items.Permafrost;
using SOTS.Items.Planetarium;
using SOTS.Items.Chaos;
using SOTS.Items.Celestial;
using static Terraria.ModLoader.ModContent;
using SOTS.Items.Planetarium.FromChests;



namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hidevisual)
        {
            SOTSPlayer sotsPlayer = SOTSPlayer.ModPlayer(player);

            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ModContent.ItemType<HarvestersScythe>())
                {
                    sotsPlayer.CritBonusMultiplier -= 0.15f;
                }

                if (item.type == ModContent.ItemType<RockCandy>())
                {
                    sotsPlayer.bonusPickaxePower -= 1;
                }

                if (item.type == ModContent.ItemType<HydrokineticAntennae>())
                {
                    sotsPlayer.StatShareMeleeAndSummon = false;
                    player.GetDamage<TrueMeleeDamageClass>() -= 0.15f;
                }



                if (InfernalCrossmod.SOTSBardHealer.Loaded)
                {
                    Mod sBH = InfernalCrossmod.SOTSBardHealer.Mod;
                    int FindItem(string name) => sBH.Find<ModItem>(name).Type;

                    if (item.type == FindItem("SerpentsTongue"))
                    {
                        SOTSPlayer.ModPlayer(player).CritBonusMultiplier -= 0.1f;
                    }
                }
            }
        }

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

            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ItemType<FrostArtifactHelmet>())
                {
                    item.defense = 13;
                }

                if (item.type == ItemType<FrostArtifactChestplate>())
                {
                    item.defense = 21;
                }

                if (item.type == ItemType<FrostArtifactTrousers>())
                {
                    item.defense = 13;
                }


                if (item.type == ItemType<TwilightAssassinsCirclet>())
                {
                    item.defense = 7;
                }

                if (item.type == ItemType<TwilightAssassinsChestplate>())
                {
                    item.defense = 9;
                }

                if (item.type == ItemType<TwilightAssassinsLeggings>())
                {
                    item.defense = 8;
                }


                if (item.type == ItemType<ElementalHelmet>())
                {
                    item.defense = 13;
                }

                if (item.type == ItemType<ElementalBreastplate>())
                {
                    item.defense = 19;
                }

                if (item.type == ItemType<ElementalLeggings>())
                {
                    item.defense = 13;
                }


                if (item.type == ItemType<VoidspaceMask>())
                {
                    item.defense = 9;
                }

                if (item.type == ItemType<VoidspaceBreastplate>())
                {
                    item.defense = 16;
                }

                if (item.type == ItemType<VoidspaceLeggings>())
                {
                    item.defense = 13;
                }
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ItemType<FrostArtifactHelmet>())
                {
                    player.GetDamage(DamageClass.Melee) -= 0.05f;
                    player.GetDamage(DamageClass.Ranged) -= 0.05f;
                }

                if (item.type == ItemType<FrostArtifactChestplate>())
                {
                    player.GetCritChance(DamageClass.Melee) -= 5f;
                    player.GetCritChance(DamageClass.Ranged) -= 5f;
                }


                if (item.type == ItemType<TwilightAssassinsCirclet>())
                {
                    player.maxMinions -= 1;
                }


                if (item.type == ItemType<ElementalBreastplate>())
                {
                    player.GetDamage(DamageClass.Melee) -= 0.2f;
                    player.GetDamage(DamageClass.Summon) -= 0.2f;
                }
            }
        }
    }

    public class SOTSModPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            if (!InfernalConfig.Instance.SOTSBalanceChanges)
                return;

            Item head = Player.armor[0];
            Item body = Player.armor[1];
            Item legs = Player.armor[2];

            bool wearingEarthen =
                head.type == ModContent.ItemType<EarthenHelmet>() &&
                body.type == ModContent.ItemType<EarthenChestplate>() &&
                legs.type == ModContent.ItemType<EarthenLeggings>();

            if (wearingEarthen)
            {
                Player.GetAttackSpeed(DamageClass.Generic) -= 0.10f;
            }
        }
    }

}
