using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindow
{
    enum PackageType
    {
        Start,
        Turn,
        Check,
        Next,
    }
    
    enum GameResult
    {
        none,
        end,
        lose,
        win
    }
}
//Start;0-server;1-client
//Turn; N = 1-9
//Check;win,lose,end,none
//Next;
