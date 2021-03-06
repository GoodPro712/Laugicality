﻿using Laugicality.Items.Loot;
using Laugicality.NPCs.Etheria;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class EmblemOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emblem of Etheria");
            Tooltip.SetDefault("Calls Etheria\n\'This seems like a terrible idea.\'");
        }

        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Etheria>(), knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime && !LaugicalityWorld.downedEtheria)
                return false;
            else if (NPC.CountNPCS(ModContent.NPCType<Etheria>()) > 0)
                return false;
            return true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 75);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe arecipe = new ModRecipe(mod);
            arecipe.AddIngredient(mod, nameof(EtherialEssence), 15);
            arecipe.AddTile(TileID.DemonAltar);
            arecipe.SetResult(this);
            arecipe.AddRecipe();
        }
	}
}