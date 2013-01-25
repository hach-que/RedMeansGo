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
        public readonly IEnumerator<double> Heartbeats;

        public RedMeansGoWorld()
        {
            this.Heartbeats = Heartbeat.HeartbeatEnumerator.YieldHeartbeats(this).GetEnumerator();
        }

        public override void DrawBelow(GameContext context)
        {
            // Clear the screen.
            if ((this.Player as Entities.Player).Health <= 0)
                context.Graphics.GraphicsDevice.Clear(Color.Black);
            else
            {
                context.Graphics.GraphicsDevice.Clear(
                new Color(
                    (float)(
                        ((1 - (this.Player as Entities.Player).Health) * 0.2) +
                    ((1 - (this.Player as Entities.Player).Health) * 0.1) *
                    (this.Heartbeats.Current / 2 + 0.5)
                    ),
                    0,
                    0
                )
                );
            }
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
            RedMeansGo.Entities.Player player = this.Player as RedMeansGo.Entities.Player;

            // Handle if player exists.
            if (player != null)
            {
                var state = Mouse.GetState();
                player.X = state.X;
                player.Y = state.Y;

                if (Keyboard.GetState().IsKeyDown(Keys.A) && player.Health > 0)
                    player.Health -= 0.001;

                if (state.LeftButton == ButtonState.Pressed)
                {
                    player.ShootSomeMotherFudgingBullets(context.World);
                }
            }

            // Update enumerator.
            this.Heartbeats.MoveNext();

            // Continue entity updates.
            return true;
        }
    }
}
