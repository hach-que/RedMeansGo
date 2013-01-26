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
    public static class PathSelector
    {
        private static Random m_Random = new Random();

        public static IEnumerator<Vector2> GetRandom()
        {
            int rand = m_Random.Next(0, 1);
            switch (rand)
            {
                case 0:
                    return new BoringPath().YieldPositions(m_Random.Next(0, 2) == 0).GetEnumerator();
                default:
                    return null;
            }
        }
    }
}

