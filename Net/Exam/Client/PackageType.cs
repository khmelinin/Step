﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    enum PackageType
    {
        Start,
        Turn,
        Check,
        Next,
        Shot,
        Miss
    }

    enum GameResult
    {
        none,
        end,
        lose,
        win
    }
}
