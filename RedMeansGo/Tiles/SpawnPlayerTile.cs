﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using RedMeansGo;
using RedMeansGo.Entities;

namespace RedMeansGo.Tiles
{
    [TileName("spawn", TilesetXmlLoader.XmlLoadMode.Entities)]
    public class SpawnPlayerTile : EntityTile
    {
        private bool m_HasSpawned = false;

        public SpawnPlayerTile(Dictionary<string, string> attributes)
        {
            this.Image = null;
            this.X = Convert.ToInt32(attributes["x"]);
            this.Y = Convert.ToInt32(attributes["y"]);
            this.Width = 32;
            this.Height = 32;
        }

        public override void Update(World rawWorld)
        {
            RedMeansGoWorld world = rawWorld as RedMeansGoWorld;

            if (!this.m_HasSpawned)
            {
                world.SpawnPlayer<Player>(this.X, this.Y);
                this.m_HasSpawned = true;
            }

            base.Update(world);
        }
    }
}
