namespace InfernalEclipseAPI.Content.Buffs
{
    public class StarboundHorrification : ModBuff
    {
        public override void SetStaticDefaults() 
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
