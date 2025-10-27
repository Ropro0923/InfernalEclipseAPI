namespace InfernalEclipseAPI.Content.Buffs
{
    public class AnchoredSoul : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            Main.pvpBuff[Type] = true;
        }
    }
}
