//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using Protogame;
using Microsoft.Xna.Framework;
using Protogame.SHMUP;

namespace RedMeansGo.Entities
{
    public class PlayerBullet : Entity
    {
        protected static Random m_Random = new Random();
        protected float m_RotationSpeed = 0;
        protected float m_Direction = -MathHelper.PiOver2;
        protected float m_Speed = 2f;

        public PlayerBullet()
        {
            this.Images = this.GetTexture("player.bullet");
            this.Width = 8;
            this.Height = 8;
            this.Origin = new Vector2(4, 4);
        }

        public override void Update(World world)
        {
            this.X += (float)(Math.Cos(this.m_Direction) * this.m_Speed);
            this.Y += (float)(Math.Sin(this.m_Direction) * this.m_Speed);
            this.Rotation += this.m_RotationSpeed;

            if (this.Y < 0)
                world.Entities.Remove(this);

            double heartbeat = (world as RedMeansGoWorld).Heartbeats.Current;
            if (((world as ShmupWorld).Player as Player).Health <= 0) heartbeat = -0.4; // You're dead :(
            this.Width = (int)(8 * (heartbeat * 0.2 + 1));
            this.Height = (int)(8 * (heartbeat * 0.2 + 1));

            var enemy = this.CollidesAt<Enemy>(world, (int)this.X, (int)this.Y);
            if (enemy != null)
                enemy.Health -= 1;

            base.Update(world);
        }
    }
}

