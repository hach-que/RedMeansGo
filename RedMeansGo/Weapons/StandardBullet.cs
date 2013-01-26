//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using RedMeansGo.Entities;
using Microsoft.Xna.Framework;

namespace RedMeansGo.Weapons
{
    public class StandardBullet : PlayerBullet
    {
        public StandardBullet()
        {
            this.m_RotationSpeed = (float)m_Random.NextDouble() * 0.1f;
            this.m_Direction = -MathHelper.PiOver2;
            this.m_Speed = 5f;
            this.Color = new Color(
                (float)m_Random.NextDouble(), 
                (float)m_Random.NextDouble(), 
                (float)m_Random.NextDouble());
        }
    }
}

