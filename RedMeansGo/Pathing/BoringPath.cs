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
            var b = 300;
            var invert = 1;
            if (arguments.Length > 0 && (bool)arguments[0])
            {
                b = 500;
                invert = -1;
            }

            for (var i = -20; i < 200; i++)
                yield return new Vector2(b + (float)Math.Cos(i / 20.0) * 50 * invert, i * 2);
            for (var i = 0; i < 300; i++)
                yield return new Vector2(b + (float)Math.Cos(10) * 50 * invert + i * 2 * invert, 400 + (float)Math.Sin(i / 20.0) * 50);
        }
    }
}

