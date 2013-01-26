//
// This source code is licensed in accordance with the licensing outlined
// on the main Tychaia website (www.tychaia.com).  Changes to the
// license on the website apply retroactively.
//
using System;
using System.Collections.Generic;

namespace RedMeansGo.Heartbeat
{
    public static class HeartbeatEnumerator
    {
        public static IEnumerable<double> YieldStopped(RedMeansGoWorld world)
        {
            yield return 0;
        }

        public static IEnumerable<double> YieldHeartbeats(RedMeansGoWorld world)
        {
            while (true)
            {
                double health = (world.Player as RedMeansGo.Entities.Player).Health;
                if (health < 0.2)
                {
                    yield return 0;
                    yield return 0.5;
                    yield return 1;
                    yield return 1;
                    yield return 0.8;
                    yield return -0.1;
                    yield return -0.7;
                    yield return -0.7;
                    yield return -0.3;
                }
                else if (health < 0.5)
                {
                    yield return 0;
                    yield return 0.01;
                    yield return 0.06;
                    yield return 0.5;
                    yield return 0.8;
                    yield return 1;
                    yield return 1;
                    yield return 1;
                    yield return 0.8;
                    yield return -0.1;
                    yield return -0.7;
                    yield return -0.7;
                    yield return -0.7;
                    yield return -0.3;
                    yield return -0.1;
                    yield return 0;
                    yield return 0.15;
                    yield return -0.05;
                }
                else
                {
                    yield return 0;
                    yield return 0;
                    yield return 0.01;
                    yield return 0.03;
                    yield return 0.06;
                    yield return 0.08;
                    yield return 0.06;
                    yield return 0.5;
                    yield return 0.8;
                    yield return 1;
                    yield return 1;
                    yield return 1;
                    yield return 0.8;
                    yield return -0.1;
                    yield return -0.7;
                    yield return -0.7;
                    yield return -0.3;
                    yield return -0.1;
                    yield return 0;
                    yield return 0.15;
                    yield return 0.2;
                    yield return 0.25;
                    yield return 0.3;
                    yield return 0.15;
                    yield return -0.05;
                }
                for (var i = 0; i < (int)(health * 30); i++)
                    yield return 0;
            }
        }
    }
}

