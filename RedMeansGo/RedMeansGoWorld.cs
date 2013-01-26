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
using RedMeansGo.Entities;

namespace RedMeansGo
{
    public class RedMeansGoWorld : ShmupWorld
    {
        public RedMeansGoGame Game { get; set; }

        public readonly IEnumerator<double> Heartbeats;
        public static Random m_Random = new Random();
        public Color BackgroundColor;
        private BackgroundAudioEntity m_BackgroundAudio;

        public RedMeansGoWorld()
        {
            this.Heartbeats = Heartbeat.HeartbeatEnumerator.YieldHeartbeats(this).GetEnumerator();
        }

        public void Restart()
        {
            if (m_BackgroundAudio != null)
                m_BackgroundAudio.Stop();
            this.Entities.Clear();
            this.SpawnPlayer<RedMeansGo.Entities.Player>(Tileset.TILESET_PIXEL_WIDTH / 2, Tileset.TILESET_PIXEL_HEIGHT - 200);

            m_BackgroundAudio = new BackgroundAudioEntity(this, "audio.heartbeat");
            m_BackgroundAudio.Start();
            this.Entities.Add(m_BackgroundAudio);
        }

        public override void DrawBelow(GameContext context)
        {
            // Clear the screen.
            if ((this.Player as Entities.Player).Health <= 0)
                context.Graphics.GraphicsDevice.Clear(Color.Black);
            else
            {
                this.BackgroundColor = new Color(
                    (float)(
                        ((1) * 0.05) +
                    ((1) * 0.15) *
                    (this.Heartbeats.Current / 2 + 0.5)
                    ),
                    0,
                    0
                );
                context.Graphics.GraphicsDevice.Clear(this.BackgroundColor);
            }

            // Create stars.
            foreach (var e in this.Entities)
                if (e is RedMeansGo.Entities.WhiteBloodCell || e is RedMeansGo.Entities.RedBloodCell)
                {
                    double heartbeat = this.Heartbeats.Current;
                    var s = (int)((heartbeat + 1) / 2 + 1);
                    if (e is RedMeansGo.Entities.WhiteBloodCell)
                    s += 5;
                    context.SpriteBatch.Draw(
                    context.Textures[e is RedMeansGo.Entities.WhiteBloodCell ? "enemy.bigbullet" : "star"], 
                    new Rectangle((int)e.X, (int)e.Y, s, s), null, e.Color, (float)e.Rotation, e.Origin, SpriteEffects.None, 1f);
                }
        }

        public override bool Update(GameContext context)
        {
            this.Game.FixResolution();

            bool handle = base.Update(context);
            if (!handle)
                return false;

            // Draw some stars if we feel like it.
            for (var i = 0; i < m_Random.NextDouble() * 150; i++)
                this.Entities.Add(new RedMeansGo.Entities.RedBloodCell {
                    X = (float)m_Random.NextDouble() * Tileset.TILESET_PIXEL_WIDTH,
                    Y = this.Player.Y - RedMeansGoGame.GAME_WIDTH / 2,
                    Speed = 3 * (float)m_Random.NextDouble() + 1
                });
            for (var i = 0; i < m_Random.NextDouble() * 150; i++)
                if (m_Random.NextDouble() < 0.05)
                    this.Entities.Add(new RedMeansGo.Entities.WhiteBloodCell {
                        X = (float)m_Random.NextDouble() * Tileset.TILESET_PIXEL_WIDTH,
                        Y = this.Player.Y - RedMeansGoGame.GAME_WIDTH / 2,
                        Speed = 3 * (float)m_Random.NextDouble() + 1
                    }
                    );

            // Cast first.
            RedMeansGo.Entities.Player player = this.Player as RedMeansGo.Entities.Player;
            m_BackgroundAudio.Tempo = (float)((1 - player.Health) + 1);

            // Move viewport to player.
            context.Graphics.GraphicsDevice.Viewport
                 = new Viewport(-(int)player.X + RedMeansGoGame.GAME_WIDTH / 2, -(int)player.Y + RedMeansGoGame.GAME_HEIGHT / 2, Tileset.TILESET_PIXEL_WIDTH, Tileset.TILESET_PIXEL_HEIGHT);

            // Handle if player exists.
            if (player != null)
            {
                /*var state = Mouse.GetState();
                player.X = state.X;
                player.Y = state.Y;*/
                
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

                if (Keyboard.GetState().IsKeyDown(Keys.A) && player.Health > 0)
                    player.Health -= 0.001;

                if (Keyboard.GetState().IsKeyDown(Keys.Z))
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
