﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;

namespace Protogame.MultiLevel
{
    public interface IMultiLevelEntity : IEntity
    {
        Level Level { set; }
    }
}
