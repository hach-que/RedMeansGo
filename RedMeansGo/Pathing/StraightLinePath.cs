using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo
{
    public class StraightLinePath : IPathing
    {
        IEnumerable<Vector2> YieldPositions(double x, double y, int direction)
        {
            int maxy = 600;
            int maxx = 800;

            switch (direction)
            {
                case 1:
                    for (int i = 0; i < maxy; i++)
                        yield return new Vector2(x, -i); 
                case 2:
                    for (int i = 0; i < maxx; i++)
                        yield return new Vector2(i, y); 
                case 3: 
                    for (int i = 0; i < maxy; i++)
                        yield return new Vector2(x, i); 
                case 4:
                    for (int i = 0; i < maxx; i++)
                        yield return new Vector2(-i, y); 
            }

        }

    }
}

