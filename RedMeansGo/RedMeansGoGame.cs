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
        public RedMeansGoGame()
        {
            this.m_GameContext.Graphics.IsFullScreen = true;
            this.m_GameContext.Graphics.PreferredBackBufferWidth = 1920;
            this.m_GameContext.Graphics.PreferredBackBufferHeight = 1080;

            // Create initial blank level.
            this.World.CreateBlankLevel("world");
			this.World.SpawnPlayer<RedMeansGo.Entities.Player>(200, 200);
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
