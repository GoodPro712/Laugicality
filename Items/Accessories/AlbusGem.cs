﻿using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AlbusGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Damage Reduction");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidAlbus", 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}