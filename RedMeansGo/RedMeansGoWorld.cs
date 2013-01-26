using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Input;
using Protogame.SHMUP;

namespace RedMeansGo
{
    public class RedMeansGoWorld : ShmupWorld
    {
        public RedMeansGoGame Game { get; set; }

        public override void DrawBelow(GameContext context)
        {
            // Clear the screen.
            context.Graphics.GraphicsDevice.Clear(Color.Black);
        }

        public override void DrawAbove(GameContext context)
        {
            XnaGraphics gr = new XnaGraphics(context);
            gr.DrawStringCentered(Tileset.TILESET_PIXEL_WIDTH / 2, 20, "Example Game!");

            base.DrawAbove(context);
        }

        public override bool Update(GameContext context)
        {
            this.Game.FixResolution();

            bool handle = base.Update(context);
            if (!handle)
                return false;

            // Cast first.
            Player player = this.Player as Player;

            // Handle if player exists.
            if (player != null)
            {
                var state = Mouse.GetState();
                player.X = state.X;
                player.Y = state.Y;

                // Send input.
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    player.MoveLeft(this);
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    player.MoveUp(this);
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    player.MoveRight(this);
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    player.MoveDown(this);
                if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Up) &&
                    Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Down))
                    player.MoveEnd();
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                    this.LoadLevel(this.CurrentLevel);
            }

            // Continue entity updates.
            return true;
        }
    }
}
