using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Protogame
{
    public class EntityTile : Tile, IEntity
    {
        public bool ImageFlipX { get; set; }
        public Vector2 ImageOrigin
        {
            get { return new Vector2(0, 0); }
            set { }
        }
        public double Rotation
        {
            get { return 0; }
            set { }
        }

        protected EntityTile()
        {
 this.Width = Tileset.TILESET_CELL_WIDTH;
            this.Height = Tileset.TILESET_CELL_HEIGHT;
            this.TX = -1;
            this.TY = -1;
        }

        public T CollidesAt<T>(World world, int x, int y) where T : Entity
        {
            return Helpers.CollidesAt<T>(this, world, x, y);
        }

        public virtual void Update(World world)
        {
        }

        public virtual void Draw(World world, XnaGraphics graphics)
        {
        }
    }
}
