using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo
{
    public class StraightLinePath : IPath
    {
        public IEnumerable<Vector2> YieldPositions(params object[] arguments)
        {
            int maxy = 600;
            int maxx = 800;

            int x = (int)arguments[0];
            int y = (int)arguments[1];
            int direction = (int)arguments[2];

            switch (direction)
            {
                case 1:
                    for (int i = 0; i < maxy; i++)
                        yield return new Vector2(x, -i); 
                    break;
                case 2:
                    for (int i = 0; i < maxx; i++)
                        yield return new Vector2(i, y); 
                    break;
                case 3: 
                    for (int i = 0; i < maxy; i++)
                        yield return new Vector2(x, i); 
                    break;
                case 4:
                    for (int i = 0; i < maxx; i++)
                        yield return new Vector2(-i, y); 
                    break;
                default:
                    break;
            }

        }

    }
}

