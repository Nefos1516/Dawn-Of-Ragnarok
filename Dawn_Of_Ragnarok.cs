using Terraria.UI;
using Terraria;
using Terraria.ModLoader;

namespace Dawn_Of_Ragnarok
{
	public class Dawn_Of_Ragnarok : Mod
	{
        public override void Load()
        {
      ModContent.GetInstance<BossKilledUI>().ShowKilledUI();
        }
    }
}