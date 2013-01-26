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
using Protogame;

namespace RedMeansGo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RedMeansGoGame : ShmupGame<RedMeansGoWorld>
    {
        #region Fix

        public static int GAME_WIDTH = 1024;
        public static int GAME_HEIGHT = 768;

        private int m_Alt = GAME_WIDTH;
        private int m_FixerCount = 0;

        public void FixResolution()
        {
            int p = (int)Environment.OSVersion.Platform;
            if ((p == 4) || (p == 128))
            {
                if (m_FixerCount++ < 60)
                {
                    this.m_Alt = this.m_Alt == GAME_WIDTH ? GAME_WIDTH - 1 : GAME_WIDTH;
                    if (Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                        Environment.OSVersion.Platform == PlatformID.Win32NT || 
                        Environment.OSVersion.Platform == PlatformID.Win32S)
                    {
                        this.m_GameContext.Graphics.IsFullScreen = false;
                        this.m_GameContext.Graphics.ApplyChanges();
                    }
                    this.m_GameContext.Graphics.SynchronizeWithVerticalRetrace = true;
                    this.m_GameContext.Graphics.PreferredBackBufferWidth = this.m_Alt;
                    this.m_GameContext.Graphics.PreferredBackBufferHeight = GAME_HEIGHT;
#if __MonoCS__
                    this.m_GameContext.Graphics.GraphicsDevice.Viewport.X = 0;
                    this.m_GameContext.Graphics.GraphicsDevice.Viewport.Y = 0;
                    this.m_GameContext.Graphics.GraphicsDevice.Viewport.Width = GAME_WIDTH;
                    this.m_GameContext.Graphics.GraphicsDevice.Viewport.Height = GAME_HEIGHT;
#endif
                    this.m_GameContext.Graphics.ApplyChanges();
                }
            }
        }

        #endregion

        public RedMeansGoGame()
        {
            this.FixResolution();

            // Create initial blank level.
            this.World.CreateBlankLevel("world");
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
            StaticWindow = this.Window;
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
            this.m_GameContext.LoadTexture("enemy.bigbullet");
            this.m_GameContext.LoadAudio("audio.heartbeat");
            this.World.Restart();
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

        private static GameWindow StaticWindow;

        public static void SetWindowTitle(string msg)
        {
            StaticWindow.Title = msg;
        }

    }
}
