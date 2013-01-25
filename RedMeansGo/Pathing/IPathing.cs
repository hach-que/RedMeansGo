using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo
{
    public interface IPathing
    {
        IEnumerable<Vector2> YieldPositions(double x, double y, int direction);
    }
}

