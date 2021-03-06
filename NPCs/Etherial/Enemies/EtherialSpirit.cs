using System;
using Laugicality.Items.Loot;
using Laugicality.NPCs.Etheria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.Enemies
{
    public class EtherialSpirit : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        public override void SetDefaults()
        {
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 68;
            npc.height = 74;
            npc.damage = 60;
            npc.defense = 80;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit54;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 5;
            npc.scale *= 2f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            bool canSpawn = true;
            foreach(NPC npc in Main.npc)
            {
                if (npc.boss)
                    canSpawn = false;
            }
            if (LaugicalityWorld.downedEtheria && canSpawn && NPC.CountNPCS(ModContent.NPCType<EtherialSpirit>()) < 2)
                return .035f;
            else return 0f;
        }

        public override void AI()
        {
            npc.rotation = 0.02f;
            if (npc.localAI[0] == 0f)
            {
                AdjustMagnitude(ref npc.velocity);
                npc.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - npc.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                npc.velocity = (12 * npc.velocity + move) / 11f;
                AdjustMagnitude(ref npc.velocity);
            }


            if (Main.netMode != 1 && Main.rand.Next(280) == 0)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<EtherialYeet>(), (int)(npc.damage / 6), 3, Main.myPlayer);
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 4f / magnitude;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 4.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight * 4)
            {
                npc.frame.Y = 0;
            }

        }
        
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EtherialEssence>(), Main.rand.Next(3, 5));            
        }
    }
}
