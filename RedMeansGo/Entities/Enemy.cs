//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RedMeansGo.Pathing;
using Protogame;

namespace RedMeansGo.Entities
{
    public class Enemy : Entity
    {
        public Enemy Parent;
        public List<Enemy> Children = new List<Enemy>();
        public IEnumerator<Vector2> Path;
        public double Health;
        private float m_RotationRandom = ((float)RedMeansGoWorld.m_Random.NextDouble() * 2 - 1) / 10;

        public Enemy()
        {
            this.Parent = null;
            this.Path = PathSelector.GetRandom();
            this.Width = 32;
            this.Height = 32;
            this.Origin = new Vector2(64, 64);
            this.Color = new Color(
                RedMeansGoWorld.m_Random.Next(0, 256),
                RedMeansGoWorld.m_Random.Next(0, 256),
                RedMeansGoWorld.m_Random.Next(0, 256));
            this.Health = RedMeansGoWorld.m_Random.Next(1, 9);
        }

        public override void Update(World world)
        {
            this.Rotation += m_RotationRandom;

            var v = this.Path.Current;
            this.X = v.X;
            this.Y = v.Y;
            if (!this.Path.MoveNext())
                world.Entities.Remove(this);

            if ((this.X != 0 || this.Y != 0) && this.Health >= 0)
                this.Images = this.GetTexture("enemy.enemy" + (int)(Math.Floor(this.Health) + 1));

            if (this.Health <= 0)
                world.Entities.Remove(this);
            
            double heartbeat = (world as RedMeansGoWorld).Heartbeats.Current;
            this.Width = (int)(32 * (heartbeat * 0.15 + 1));
            this.Height = (int)(32 * (heartbeat * 0.15 + 1));

            base.Update(world);
        }
    }
}

