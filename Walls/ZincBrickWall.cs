using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Walls
{
	public class ZincBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			dustType = 1;
			AddMapEntry(new Color(20, 60, 30));
            drop = ModContent.ItemType<Items.Placeable.ZincBrickWall>();
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
	}
}