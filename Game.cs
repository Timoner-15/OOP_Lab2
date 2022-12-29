using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    public abstract class Game 
    {
        public double Point { get; }
        public string Opponent { get; }
        public Game(double point, string uOpponent)
        {
            Point = point;
            Opponent = uOpponent;
        }
        #region GamesDeclaration
        private List<Game> allGames = new List<Game>();
        #endregion
    }
}
