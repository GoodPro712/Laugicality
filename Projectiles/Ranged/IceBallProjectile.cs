﻿using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class IceBallProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
            projectile.ai[0] += 0.02f;
            projectile.velocity.X *= .975f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}