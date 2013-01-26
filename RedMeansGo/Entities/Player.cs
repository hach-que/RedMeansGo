using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using Protogame.Platformer;
using Protogame.Particles;
using Microsoft.Xna.Framework;
using RedMeansGo.Weapons;

namespace RedMeansGo.Entities
{
    public class Player : Protogame.SHMUP.Player
    {
        // Settings
        public override float PlayerMovementSpeed
        {
            get
            {
                if (this.m_World == null)
                    return 0;
                return (float)(4 * (1 - ((this.m_World as RedMeansGoWorld).Player as Player).Health + 1));
            }
        }

        private RedMeansGoWorld m_World;
        public override float PlayerJumpSpeed { get { return 5; } }
        public Color PowerupColor = new Color(255, 0, 0);
        private Random m_Random = new Random();
        public double Health { get; set; }
        public IWeapon Weapon { get; set ;}

        private const int WIDTH = 15;
        private const int HEIGHT = 15;

        public Player()
        {
			this.Images = this.GetTexture("player.main");
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.ImageSpeed = 5;
            this.Origin = new Vector2(31, 31);
            this.Health = 1;
            this.Weapon = new StandardWeapon();
        }

		public override void Draw(World world, XnaGraphics graphics)
		{
            this.m_World = world as RedMeansGoWorld;
            base.Draw(world, graphics);

            graphics.DrawSprite((int)this.X, (int)this.Y, this.Width - 8, this.Height - 8, "player.powerup", this.PowerupColor, false, this.Rotation,
                                new Vector2(54 / 2, 54 / 2));

            string msg;
            if (this.Health <= 0)
                msg = "You win.  They died.";
            else
                msg = "Distance to Heart: " + (this.Health * 150).ToString("F2") + "cm";
            graphics.DrawStringCentered((int)this.X, (int)this.Y + 40, msg);
            RedMeansGoGame.SetWindowTitle(msg);
		}

        public override void Update(World world)
        {
            this.m_World = world as RedMeansGoWorld;
            base.Update(world);

            // Game pace is set by player health...  reduce it very very slowly.
            this.Health -= 0.0001;

            //this.PowerupColor = new Color((float)m_Random.NextDouble(), (float)m_Random.NextDouble(), (float)m_Random.NextDouble());
            if (this.Health <= 0)
                this.PowerupColor = new Color(127, 127, 127);
            else
                this.Rotation += 0.1 * ((1 - this.Health) * 0.3 + 1);

            double heartbeat = (world as RedMeansGoWorld).Heartbeats.Current;
            if (this.Health <= 0)
                heartbeat = -0.4; // You're dead :(
            this.Width = (int)(WIDTH * (heartbeat * 0.15 + 1));
            this.Height = (int)(HEIGHT * (heartbeat * 0.15 + 1));
            //this.Origin = new Vector2(this.Width / 2, this.Height / 2);

            if (this.X < RedMeansGoGame.GAME_WIDTH / 2)
            {
                foreach (var e in world.Entities)
                    e.X += Tileset.TILESET_PIXEL_WIDTH - RedMeansGoGame.GAME_WIDTH;
            }
            if (this.X > Tileset.TILESET_PIXEL_WIDTH - RedMeansGoGame.GAME_WIDTH / 2)
            {
                foreach (var e in world.Entities)
                    e.X -= Tileset.TILESET_PIXEL_WIDTH - RedMeansGoGame.GAME_WIDTH;
            }
            if (this.Y > Tileset.TILESET_PIXEL_HEIGHT - RedMeansGoGame.GAME_HEIGHT / 2)
                this.Y = Tileset.TILESET_PIXEL_HEIGHT - RedMeansGoGame.GAME_HEIGHT / 2;
            if (this.Y < RedMeansGoGame.GAME_HEIGHT / 2)
            {
                foreach (var e in world.Entities)
                    e.Y += Tileset.TILESET_PIXEL_HEIGHT - RedMeansGoGame.GAME_HEIGHT;
            }
        }

        public override void MoveUp(World world)
        {
            this.Health -= 0.0002;

            base.MoveUp(world);
        }

        public override void MoveDown(World world)
        {
            this.Health += 0.0002;

            base.MoveDown(world);
        }

        public void ShootSomeMotherFudgingBullets(World world)
        {
            this.Weapon.Fire(world, this);
        }
    }
}
