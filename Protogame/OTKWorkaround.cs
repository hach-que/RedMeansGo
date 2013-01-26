using System;
using Microsoft.Xna.Framework;

namespace Protogame
{
    public class OTKWorkaround
    {
        private int m_ApplyCount = 0;

        /// <summary>
        /// OTK has buggy window handling on Linux...
        /// </summary>
        public void FixOTKBugsOnLinux(GraphicsDeviceManager manager)
        {
            if (m_ApplyCount++ < 60 * 2)
                manager.ApplyChanges();
        }
    }
}

