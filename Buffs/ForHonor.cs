using Terraria;

namespace Laugicality.Buffs
{
	public class ForHonor : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("For Honor");
			Description.SetDefault("+15% Damage \nDefense Halved");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).HalfDef = true;
            player.allDamage += 0.15f;
        }
        
    }
}
