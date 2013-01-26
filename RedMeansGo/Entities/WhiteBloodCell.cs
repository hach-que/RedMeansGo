//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using Protogame;
using Protogame.SHMUP;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Entities
{
    public class WhiteBloodCell : Entity
    {
        public float Speed { get; set; }

        public override void Update(World world)
        {
            this.Y += this.Speed;
            this.X += (float)(Math.Cos(this.Y / 200) * this.Speed);
            this.Rotation += 0.05f;

            if (this.Y > Tileset.TILESET_PIXEL_HEIGHT)
                world.Entities.Remove(this);

            this.Color = new Color(255, 255, 255);

            /*var w = world as RedMeansGoWorld;
            if (w.Player.X - this.X < 60 && w.Player.X - this.X > -60 && 
                w.Player.Y - this.Y < 60 && w.Player.Y - this.Y > -60)
            {
                if (Vector2.Distance(
                    new Vector2(this.X, this.Y),
                    new Vector2(w.Player.X, w.Player.Y)) < 16)
                    (world as RedMeansGoWorld).Restart();
            }*/

            base.Update(world);
        }
    }
}

