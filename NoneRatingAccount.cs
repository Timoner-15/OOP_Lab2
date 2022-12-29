using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    class NoneRatingAccount
    {
        public string UserName { get; set; }
        public double GamesCount { get; }
        public double CurrentRating
        {
            get
            {
                double aCurrentRating = 0;
                foreach (var item in allGames)
                {
                    aCurrentRating += item.Point;
                }

                return aCurrentRating;
            }
        }

        #region GamesDeclaration
        private List<Game> allGames = new List<Game>();
        #endregion

        #region Constructor
        public NoneRatingAccount(string aUserName, string uOpponent, double point)
        {
            UserName = aUserName;
            ArcWinGame(/*opponent*/uOpponent, point);
        }

        #region GamesDeclaration
        private List<ArcadeGame> allArcadeGames = new List<ArcadeGame>();
        #endregion

        #region ArcWinGame
        public void ArcWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            var arcwin = new ArcadeGame(point, uOpponent);
            allArcadeGames.Add(arcwin);
        }
        #endregion

        #region ArcLoseGame
        public void ArcLoseGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of points can't be negative");
            }
            if (CurrentRating - point < -1)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var arclose = new ArcadeGame(point, uOpponent);
            allArcadeGames.Add(arclose);
        }
        #endregion

        #region GetStats
        int index = 1;
        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("№\tOpponent");
            foreach (var item in allArcadeGames)
            {

                report.AppendLine($"{index++}\t{item.Bot}");

            }
            return report.ToString();
        }
        #endregion
        #endregion
    }

}
