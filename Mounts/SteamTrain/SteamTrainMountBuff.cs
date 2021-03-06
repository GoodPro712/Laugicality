using Laugicality.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Mounts.SteamTrain
{
	public class SteamTrainMountBuff : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Train");
			Description.SetDefault("Choo Choo!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<SteamTrainMount>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
