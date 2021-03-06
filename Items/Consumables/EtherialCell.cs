﻿using Laugicality.Items.Loot;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class EtherialCell : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Etherial Crown");
            Tooltip.SetDefault("Summons Golem");
        }

        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.Golem, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.GolemHead, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.GolemFistLeft, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.GolemFistRight, knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (LaugicalityWorld.downedEtheria && NPC.CountNPCS(NPCID.GolemHead) < 1 && NPC.CountNPCS(NPCID.GolemHeadFree) < 1);
        }
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod, nameof(EtherialEssence), 5);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult((ItemID.LihzahrdPowerCell));

			recipe.AddRecipe();
        }
	}
}