using Microsoft.Xna.Framework;
using System;
using Laugicality.Buffs;
using Laugicality.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class DaysBreak : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunrise");
            Tooltip.SetDefault("'Bring the dawn'\nStriking enemies makes them emit sparks\nEnemies explode into sparks on death, spreading the dawn.");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
            item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 10f;
            item.shoot = ModContent.ProjectileType<GoldenSword>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f/180f;
            float mag = 600;
            Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(player.position.Y) + (int)(mag * Math.Sin(theta)), -15 * (float)Math.Cos(theta), -15 * (float)Math.Sin(theta), ModContent.ProjectileType<DawnStar>(), damage, 3, Main.myPlayer);
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<DawnBuff>(), 5 * 60 + Main.rand.Next(3 * 60));
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ModContent.ItemType<Flarance>());
            recipe.AddIngredient(ModContent.ItemType<Mariana>());
            recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();


            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.SunplateBlock, 20);
            recipe2.AddTile(null, "LaugicalWorkbench");
            recipe2.SetResult(ItemID.SkyMill);
            recipe2.AddRecipe();
        }
	}
}