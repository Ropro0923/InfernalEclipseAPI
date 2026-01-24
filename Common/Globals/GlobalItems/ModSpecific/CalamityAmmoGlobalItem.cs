using CalamityMod;
using CalamityMod.Items.Weapons.Melee;
using InfernalEclipseAPI.Core.Systems;
using ThoriumMod;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.BossFallenBeholder;
using ThoriumMod.Items.BossForgottenOne;
using ThoriumMod.Items.BossGraniteEnergyStorm;
using ThoriumMod.Items.BossThePrimordials.Aqua;
using ThoriumMod.Items.BossThePrimordials.Slag;
using ThoriumMod.Items.Bronze;
using ThoriumMod.Items.Coral;
using ThoriumMod.Items.Cultist;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Donate;
using ThoriumMod.Items.Flesh;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Icy;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Sandstone;
using ThoriumMod.Items.Thorium;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Valadium;
using static Terraria.ModLoader.ModContent;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled(InfernalCrossmod.Thorium.Name)]
    [ExtendsFromMod("ThoriumMod")]
    public class CalamityAmmoGlobalItem : GlobalItem
    {
        public override void UpdateEquip(Item item, Player player)
        {
            if (!InfernalConfig.Instance.CalamityBalanceChanges)
                return;

            if (!ModLoader.TryGetMod("CalamityAmmo", out Mod calamityAmmo))
                return;

            if (calamityAmmo.TryFind<ModItem>("WulfrumCoil", out ModItem coil))
            {
                player.GetDamage(DamageClass.Ranged) -= 0.02f;
            }
        }
    }
}
