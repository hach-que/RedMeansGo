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
        public override float PlayerMovementSpeed { get { return 4; } }
        public override float PlayerJumpSpeed { get { return 5; } }
        public Color PowerupColor = new Color(255, 0, 0);
        private Random m_Random = new Random();
        public double Health { get; set; }
        public IWeapon Weapon { get; set ;}

        private const int WIDTH = 62;
        private const int HEIGHT = 62;

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
            base.Draw(world, graphics);

            graphics.DrawSprite((int)this.X, (int)this.Y, this.Width - 8, this.Height - 8, "player.powerup", this.PowerupColor, false, this.Rotation,
                                new Vector2(54 / 2, 54 / 2));
            //graphics.DrawStringCentered((int)this.X, (int)this.Y, this.Health.ToString());
		}

        public override void Update(World world)
        {
            base.Update(world);

            //this.PowerupColor = new Color((float)m_Random.NextDouble(), (float)m_Random.NextDouble(), (float)m_Random.NextDouble());
            if (this.Health <= 0)
                this.PowerupColor = new Color(127, 127, 127);
            else
                this.Rotation += 0.1 * ((1 - this.Health) * 0.3 + 1);

            double heartbeat = (world as RedMeansGoWorld).Heartbeats.Current;
            if (this.Health <= 0) heartbeat = -0.4; // You're dead :(
            this.Width = (int)(WIDTH * (heartbeat * 0.15 + 1));
            this.Height = (int)(HEIGHT * (heartbeat * 0.15 + 1));
            //this.Origin = new Vector2(this.Width / 2, this.Height / 2);
        }

        public void ShootSomeMotherFudgingBullets(World world)
        {
            this.Weapon.Fire(world, this);
        }
    }
}
