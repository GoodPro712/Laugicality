using Laugicality.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class ArcticHydraBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Arctic Hydra");
            Description.SetDefault("The Hydra Hoard will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ArcticHydraHead>()] > 0)
            {
                modPlayer.ArcticHydraSummon = true;
            }
            if (!modPlayer.ArcticHydraSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}