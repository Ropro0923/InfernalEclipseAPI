namespace InfernalEclipseAPI.Content.Items.Weapons.Legendary.Lycanroc
{
    public class LycanrocGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public bool appliesCrumbling = false;
        public bool appliesArmorCrunch = false;
    }
}
