using Laugicality.Items.Loot;
using Laugicality.NPCs.Etheria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SuperCorruptor : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        private int _delay = 0;
        private int _shootDelay = 0;
        private int _index = 0;
        private Vector2 _targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 10f;
        public float vAccel = .2f;
        public float vMag = 0f;
        private float _theta = 0;
        private int _targetType = 0;

        public override void SetDefaults()
        {
            _shootDelay = 0;
            _targetType = 0;
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            _index = 0;
            _delay = 0;
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 36;
            npc.height = 36;
            npc.damage = 40;
            npc.defense = 80;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 5;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 3;
        }
        
        public override void AI()
        {
            MovementType(npc);
            Shoot(npc);
            npc.active = CheckActive();
        }
        
        private void MovementType(NPC npc)
        {
            _delay++;
            if (_delay > 480)
            {
                _delay = Main.rand.Next(1, 120);
                MirrorTeleport(npc, false);
                
            }
        }

        private void Shoot(NPC npc)
        {
            _shootDelay++;
            if (_shootDelay > 480)
            {
                _shootDelay = Main.rand.Next(1, 120);
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<EtherialYeet>(), (int)(npc.damage / 4), 3, Main.myPlayer);
            }
        }
        
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EtherialEssence>(), 1);
        }

        private void MirrorTeleport(NPC npc, bool burst)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            if (burst && Main.player[npc.target].statLife > 1)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (Main.netMode != 1)
                    {
                        int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EtherialSpiralShot>());
                        Main.npc[n].ai[0] = npc.whoAmI;
                        Main.npc[n].ai[1] = i;
                    }
                }
            }
            npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X);
            npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y);
            npc.velocity.X = -npc.velocity.X;
            npc.velocity.Y = -npc.velocity.Y;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 24.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight * 2)
            {
                npc.frame.Y = 0;
            }
        }
    }
}
