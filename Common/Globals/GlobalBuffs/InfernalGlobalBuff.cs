using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfernalEclipseAPI.Core.Systems;

namespace InfernalEclipseAPI.Common.Globals.GlobalBuffs
{
    public class InfernalGlobalBuff : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (InfernalCrossmod.SOTS.Loaded)
            {
                Mod sots = InfernalCrossmod.SOTS.Mod;
            }
        }
    }
}
