using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using Protogame.Platformer;
using Protogame.Particles;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Entities
{
    public class Player : Protogame.SHMUP.Player
    {
        // Settings
        public override float PlayerMovementSpeed { get { return 4; } }
        public override float PlayerJumpSpeed { get { return 5; } }
        public Color PowerupColor = new Color(0, 255, 0);
        private Random m_Random = new Random();

        public Player()
        {
			this.Images = this.GetTexture("player.main");
            this.Width = 62;
            this.Height = 62;
            this.ImageSpeed = 5;
            this.Origin = new Vector2(31, 31);
        }

		public override void Draw (World world, XnaGraphics graphics)
		{
            base.Draw(world, graphics);

            graphics.DrawSprite((int)this.X, (int)this.Y, 54, 54, "player.powerup", this.PowerupColor, false, this.Rotation,
                                new Vector2(54 / 2, 54 / 2));
		}

        public override void Update(World world)
        {
            base.Update(world);

            this.PowerupColor = new Color((float)m_Random.NextDouble(), (float)m_Random.NextDouble(), (float)m_Random.NextDouble());
            this.Rotation += 0.1;
        }
    }
}
