using Laugicality.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WebmilioCommons.Extensions;

namespace Laugicality.Tiles
{
    public class ObsidiumGrass : AmelderaTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = ModContent.DustType<Magma>();
            //drop = ModContent.ItemType<LavaGem>();
            ModTranslation name = CreateMapEntryName();
            //name.SetDefault("LavaGem");
            //AddMapEntry(new Color(180, 50, 0), name);
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            soundType = 6;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                ModContent.TileType<Lycoris>(),
                ModContent.TileType<Tiles.Radiata>()
            };
            TileObjectData.addTile(Type);

            obsidiumTexture = this.GetType().GetTexture();
            amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/Eldergrass");
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if ((i % 8) < 4)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
                frameYOffset = i % 4 * 18;
        }
        
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .1f;
            g = 0.05f;
            b = 0.0f;
        }
        
    }
}