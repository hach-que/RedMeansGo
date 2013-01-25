using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using Protogame.Platformer;
using Protogame.Particles;
using Microsoft.Xna.Framework;

namespace Protogame.SHMUP
{
    public abstract class Player : Entity
    {
        public virtual float PlayerMovementSpeed { get { return 4; } }
        public virtual float PlayerJumpSpeed { get { return 5; } }
        public virtual Vector2 AimTarget { get; set; }

        protected Player()
        {
        }

        public bool CollidesWithSolidAt(World world, int x, int y)
        {
            return Helpers.CollidesWithSolidAt(this, world, x, y);
        }

        public virtual void MoveLeft(World world)
        {
            if (this.CollidesWithSolidAt(world, (int)(this.X - this.PlayerMovementSpeed), (int)this.Y - 1))
                this.MoveUntilContact(world, -1, 0, this.PlayerMovementSpeed);
            else
                this.X -= this.PlayerMovementSpeed;
        }

        public virtual void MoveUp(World world)
        {
            if (this.CollidesWithSolidAt(world, (int)(this.X - 1), (int)(this.Y - this.PlayerMovementSpeed)))
                this.MoveUntilContact(world, 0, -1, this.PlayerMovementSpeed);
            else
                this.Y -= this.PlayerMovementSpeed;
        }

        public virtual void MoveRight(World world)
        {
            if (this.CollidesWithSolidAt(world, (int)(this.X + this.PlayerMovementSpeed), (int)this.Y + 1))
                this.MoveUntilContact(world, 1, 0, this.PlayerMovementSpeed);
            else
                this.X += this.PlayerMovementSpeed;
        }

        public virtual void MoveDown(World world)
        {
            if (this.CollidesWithSolidAt(world, (int)(this.X + 1), (int)(this.Y + this.PlayerMovementSpeed)))
                this.MoveUntilContact(world, 0, 1, this.PlayerMovementSpeed);
            else
                this.Y += this.PlayerMovementSpeed;
        }

        public virtual void MoveEnd()
        {
        }

        public virtual void Action(World world)
        {
        }

        public virtual void Aim(float x, float y)
        {
            this.AimTarget = new Vector2(x, y);
        }

        public override void Update(World world)
        {
            base.Update(world);

            // Movement handling.
            this.XSpeed = 0;
            this.YSpeed = 0;

            // Death.
            if (this.Y > Tileset.TILESET_PIXEL_HEIGHT)
                world.LoadLevel(world.CurrentLevel);
        }
    }
}
