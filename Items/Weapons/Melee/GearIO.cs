using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class GearIO : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geariken");
            Tooltip.SetDefault("Don't prick yourself!");

            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 19;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 32;
            item.height = 26;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 2.5f;
            item.damage = 100;
            item.rare = ItemRarityID.Orange;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = ModContent.ProjectileType<GearIOProjectile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 12);
            recipe.AddIngredient(mod, nameof(Gear), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
