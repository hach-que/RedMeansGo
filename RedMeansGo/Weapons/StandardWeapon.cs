//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using RedMeansGo.Entities;
using Protogame;

namespace RedMeansGo.Weapons
{
    public class StandardWeapon : IWeapon
    {
        public void Fire(World world, Player player)
        {
            world.Entities.Add(new StandardBullet { X = player.X, Y = player.Y });
        }
    }
}

