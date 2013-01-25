using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Entities
{
    public class EnemyGenerator
    {
        public EnemyGenerator()
        {
            int Level; //1 = triangle, counts up per side
            int PackSize; //Makes the next X amount of enemies to be the exact same as this enemy.
            int Color; 
            int EnemySize;
            int EnemyChildren;
            // Generate child, repeats top things

            /*
            Enemy Parent;
            Enemy[] Child;
            */
            IEnumerable<Vector2> Path;
        }
    }
}

