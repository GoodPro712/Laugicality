using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
{
    public class BysmalRipperProjectile : ModProjectile
    {
        public bool justSpawned = false;
        Vector2 initVel;
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.velocity.Y += .25f;
            if(!justSpawned)
            {
                initVel = projectile.velocity;
                justSpawned = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(Main.myPlayer == projectile.owner)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                float mag = 120;
                if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(Main.player[projectile.owner]).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
                {
                    theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                    mag = 120;
                    Projectile.NewProjectile(target.Center.X + (int)(mag * Math.Cos(theta)), target.Center.Y + (int)(mag * Math.Sin(theta)), -8 * (float)Math.Cos(theta), -8 * (float)Math.Sin(theta), ModContent.ProjectileType<BysmalRipperShadow>(), damage, 3, Main.myPlayer);
                }
                theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                mag = 120;
                Projectile.NewProjectile(target.Center.X + (int)(mag * Math.Cos(theta)), target.Center.Y + (int)(mag * Math.Sin(theta)), -8 * (float)Math.Cos(theta), -8 * (float)Math.Sin(theta), ModContent.ProjectileType<BysmalRipperShadow>(), damage, 3, Main.myPlayer);
            }
        }
    }
}