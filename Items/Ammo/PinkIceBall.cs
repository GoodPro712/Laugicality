using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class PinkIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearlfrost Ball");
            Tooltip.SetDefault("The hallowed ice is much lighter, and able to fly much farther.");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.PinkIceBallProjectile>();
            item.shootSpeed = 16f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkIceBlock, 1);
            recipe.SetResult(this, 12);
            recipe.AddRecipe();
        }
    }
}
