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
    public interface IWeapon
    {
        void Fire(World world, Player player);
    }
}

