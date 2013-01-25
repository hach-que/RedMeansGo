//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using Protogame;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Entities
{
    public class PlayerBullet : Entity
    {
        private static Random m_Random = new Random();
        private float m_RotationSpeed = (float)m_Random.NextDouble() * 0.1f;
        private float m_Direction = (float)(-MathHelper.PiOver2 - MathHelper.PiOver4 + m_Random.NextDouble() * MathHelper.PiOver2);
        private float m_Speed = 5f + (float)m_Random.NextDouble() * 7.5f;

        public PlayerBullet()
        {
            this.Images = this.GetTexture("player.bullet");
            this.Width = 5;
            this.Height = 5;
            this.Origin = new Vector2(2, 2);
            this.Color = new Color(
                (float)m_Random.NextDouble(), 
                (float)m_Random.NextDouble(), 
                (float)m_Random.NextDouble());
        }

        public override void Update(World world)
        {
            this.X += (float)(Math.Cos(this.m_Direction) * this.m_Speed);
            this.Y += (float)(Math.Sin(this.m_Direction) * this.m_Speed);
            this.Rotation += this.m_RotationSpeed;

            if (this.Y < 0)
                world.Entities.Remove(this);

            base.Update(world);
        }
    }
}

