using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    public class ArcadeGame : Game
    {
        public string Bot { get;}
        public ArcadeGame(double point ,string uOpponent) : base(point, uOpponent)
        {
            Bot = uOpponent;
        }
    }
}
