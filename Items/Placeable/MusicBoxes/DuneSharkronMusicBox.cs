using Laugicality.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.MusicBoxes
{
    public class DuneSharkronMusicBox : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Dune Sharkron)");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType<Tiles.MusicBoxes.DuneSharkronMusicBox>();
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(ModContent.TileType<Tiles.LaugicalWorkbench>());
            recipe.AddIngredient(ItemID.MusicBox, 1);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 5);
            recipe.AddIngredient(ItemID.FossilOre, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}