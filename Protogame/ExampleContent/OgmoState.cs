﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protogame.ExampleContent
{
    /// <summary>
    /// In order to use this class you will need to copy this class and OgmoRunner to
    /// your game (don't uncomment it here!).  Your game will also need to reference
    /// the OgmoEditor.Protogame assembly that comes with Ogmo Editor.
    /// </summary>
#if EXAMPLE
    public class OgmoState : TransparentFocusableObject
    {
        private RuntimeGame m_Game = null;

        public OgmoState(RuntimeGame game)
        {
            this.m_Game = game;
        }

        [Category("Multiplayer")]
        [Description("Is the game currently waiting for the multiplayer lobby to finish?")]
        public bool MultiplayerWaiting
        {
            get
            {
                return this.m_Game.World.GlobalSession.Waiting;
            }
        }

        [Category("Multiplayer")]
        [Description("The number of players that are currently in the game.")]
        public int PlayerCount
        {
            get
            {
                return this.m_Game.World.GlobalSession.Players.Count;
            }
        }

        [Category("Multiplayer")]
        [Description("The local player ID.")]
        public int PlayerID
        {
            get
            {
                return this.m_Game.World.LocalPlayer.PlayerID;
            }
        }

        [Category("Performance")]
        [Description("The number of entities active in the game world.")]
        public int EntityCount
        {
            get
            {
                return this.m_Game.World.ActiveLevel.Entities.Count;
            }
        }

        [Category("Performance")]
        [Description("The number of ticks since the game started.")]
        public long WorldTime
        {
            get
            {
                return this.m_Game.World.Tick;
            }
        }

        [Category("State")]
        [Description("The number of units currently selected.")]
        public int SelectedUnitCount
        {
            get
            {
                return this.m_Game.World.UiManager.Selected.Count;
            }
        }
    }
#endif
}
