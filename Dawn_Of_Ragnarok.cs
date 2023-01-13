using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;

namespace Dawn_Of_Ragnarok
{
    public static class Globals
    {
        public static List<int> consumedBosses = new List<int>();
    }

	public class Dawn_Of_Ragnarok : Mod
	{
        
    
    }
    public class CallForUI : GlobalNPC
    {
        public static int killedBossType = 0;
        public override bool PreKill(NPC npc)
        {
            if (npc.boss)
            {
                ModContent.GetInstance<BossKilledUI>().ShowKilledUI();
                killedBossType = npc.type;
            }
            return true;
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (Globals.consumedBosses.Contains(npc.type))
            {
                npc.active = false;
                Main.NewText("But nobody came...", Color.DimGray);
            }
        }

        public int GetMinionType()
        {
            return killedBossType;
        }
    }
}