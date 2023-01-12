using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Dawn_Of_Ragnarok
{
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

        public int GetMinionType()
        {
            return killedBossType;
        }
    }
}