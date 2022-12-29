using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;  
using System.Threading.Tasks;

namespace Lb1
{
    class EasyGameAccount
    {
        public string UserName { get; set; }
        public double GamesCount { get; }
        #region RatingComputation
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

        public EasyGameAccount(string aUserName, string uOpponent, double point)
        {
            UserName = aUserName;
            EasyBasicWinGame(/*opponent*/uOpponent, point);
        }

        #region GamesDeclaration
        private List<Game> allGames = new List<Game>();
        #endregion



        #region WinGame
        public void EasyBasicWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            var basewin = new BasicGame(point, uOpponent);
            allGames.Add(basewin);
        }
        #endregion
        #region LoseGame
        public void EasyBasicLoseGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            if (point >= 0)
            {
                point = 0;
                var baselose = new BasicGame(-point, uOpponent);
                allGames.Add(baselose);
            }
        }
        #endregion

        public void EasyAllinWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            point = CurrentRating;
            var allinwin = new AllinGame(point, uOpponent);
            allGames.Add(allinwin);
        }


        public void EasyAllinLoseGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of points can't be negative");
            }
            if (CurrentRating - point < -1)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            point = CurrentRating;
            var allinlose = new AllinGame(-point, uOpponent);
            allGames.Add(allinlose);
        }

        public void EasyArcadeWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            var arcadewin = new ArcadeGame(point, uOpponent);
            allGames.Add(arcadewin);
        }

        public void EasyArcadeLoseGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of points can't be negative");
            }
            if (CurrentRating - point < -1)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var arcadelose = new ArcadeGame(-point, uOpponent);
            allGames.Add(arcadelose);
        }


        #region GetStats
        int index = 1;
        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

            double aCurrentRating = 0;

            report.AppendLine("№\tPoint\tRating\tOpponent");
            foreach (var item in allGames)
            {

                aCurrentRating += item.Point;

                report.AppendLine($"{index++}\t{item.Point}\t{aCurrentRating}\t{item.Opponent}");

            }

            return report.ToString();
        }
        #endregion
    }

}
#endregion