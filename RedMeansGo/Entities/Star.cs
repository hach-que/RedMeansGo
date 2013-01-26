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
    public class Star : Entity
    {
        public float Speed { get; set; }

        public override void Update(World world)
        {
            this.Y += this.Speed;

            if (this.Y > Tileset.TILESET_PIXEL_HEIGHT)
                world.Entities.Remove(this);

            this.Color = new Color(255, 255 - (world as RedMeansGoWorld).BackgroundColor.R * 2,
                                   255 - (world as RedMeansGoWorld).BackgroundColor.R * 2);

            base.Update(world);
        }
    }
}

