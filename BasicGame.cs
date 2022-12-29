using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    public class BasicGame : Game
    {
        public BasicGame(double point, string uOpponent) : base(point, uOpponent)
        {
        }
        public void GamePoints(double point)
        {
            Random gamepoints = new Random();
            point = gamepoints.Next(10, 20);
        }
    }
}
