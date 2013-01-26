//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Pathing
{
    public class BoringPath : IPath
    {
        public IEnumerable<Vector2> YieldPositions(params object[] arguments)
        {
            for (var i = 0; i < 200; i++)
                yield return new Vector2(40, i * 2);
        }
    }
}

