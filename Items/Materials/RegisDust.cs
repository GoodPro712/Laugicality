﻿using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class RegisDust : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The wealth of knowledge'");
        }
        public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst, 1);
            recipe.AddIngredient(null, "ArcaneShard", 1);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this, 2);
            recipe.AddRecipe();

            

        }
	}
}