using Terraria;

namespace Laugicality.Buffs
{
	public class TrueCurse : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Curse");
			Description.SetDefault("You truly can do nothing");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).TrueCurse = true;
		}
	}
}
