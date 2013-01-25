using System;

namespace Protogame.SHMUP
{
    public class ShmupGame<T> : CoreGame<T> where T : ShmupWorld, new()
    {
    }
}

