using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Protogame.SHMUP;
using RedMeansGo.Entities;

namespace RedMeansGo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RedMeansGoGame : ShmupGame<RedMeansGoWorld>
    {
        #region Fix

        private int m_Alt = 800;
        private int m_FixerCount = 0;

        public void FixResolution()
        {
            int p = (int)Environment.OSVersion.Platform;
            if ((p == 4) || (p == 128))
            {
                if (m_FixerCount++ < 60)
                {
                    this.m_Alt = this.m_Alt == 800 ? 801 : 800;
                    this.m_GameContext.Graphics.SynchronizeWithVerticalRetrace = true;
                    this.m_GameContext.Graphics.PreferredBackBufferWidth = this.m_Alt;
                    this.m_GameContext.Graphics.PreferredBackBufferHeight = 600;
                    this.GraphicsDevice.Viewport.X = 0;
                    this.GraphicsDevice.Viewport.Y = 0;
                    this.GraphicsDevice.Viewport.Width = 800;
                    this.GraphicsDevice.Viewport.Height = 600;
                    this.m_GameContext.Graphics.ApplyChanges();
                }
            }
        }

        #endregion

        public RedMeansGoGame()
        {
            this.FixResolution();
            this.IsMouseVisible = false;

            // Create initial blank level.
            this.World.CreateBlankLevel("world");
			this.World.SpawnPlayer<RedMeansGo.Entities.Player>(200, 200);
            this.World.Game = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.Window.Title = "Red Means Go!";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Load protogame's content.
            base.LoadContent();

            // Load all the textures.
            this.m_GameContext.LoadFont("Arial");
            this.m_GameContext.LoadTexture("player.main");
            this.m_GameContext.LoadTexture("player.powerup");
            this.m_GameContext.LoadTexture("player.bullet");
            this.m_GameContext.LoadTexture("star");
            this.m_GameContext.LoadAudio("audio.sfx.example");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }
    }
}
