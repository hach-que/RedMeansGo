//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Entities
{
    public class Enemy
    {
        public Enemy Parent;
        public List<Enemy> Children = new List<Enemy>();
        public IEnumerator<Vector2> Path;

        public Enemy()
        {
            this.Parent = null;
            this.Path = PathSelector.GetRandom();
        }
    }
}

