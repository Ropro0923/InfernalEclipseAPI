using CalamityMod.Items.Weapons.Melee;
using ThoriumMod;
using ThoriumMod.Items.Cultist;

namespace InfernalEclipseAPI.Common.GlobalItems
{
    [ExtendsFromMod("ThoriumMod")]
    public class WeaponToThoriumWeaponClass : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
            if (InfernalConfig.Instance.ChanageWeaponClasses) 
            {
                if (entity.type == ItemID.TheAxe)
                {
                    entity.DamageType = ThoriumDamageBase<BardDamage>.Instance;
                }

                if (entity.type == ModContent.ItemType<AncientFlame>())
                {
                    entity.DamageType = ThoriumDamageBase<HealerDamage>.Instance;
                    entity.damage = 32;
                }

                if (entity.type == ModContent.ItemType<TheBurningSky>())
                {
                    entity.DamageType = ThoriumDamageBase<HealerDamage>.Instance;
                    entity.mana = 35;
                }
            }
        }
    }
}
