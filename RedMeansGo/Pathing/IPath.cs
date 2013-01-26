using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo
{
    public interface IPath
    {
        IEnumerable<Vector2> YieldPositions(params object[] arguments);
    }
}

