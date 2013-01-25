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

        public Player()
        {
            this.Images = this.GetTextureAnim("player.frame", 1);
            this.Width = 32;
            this.Height = 32;
            this.ImageSpeed = 5;
            this.ImageOrigin = new Vector2(16, 16);
        }

        public override void Update(World world)
        {
            base.Update(world);

            this.Rotation += 0.1;
        }
    }
}
