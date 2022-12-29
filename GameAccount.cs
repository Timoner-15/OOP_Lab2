using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lb1
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public double GamesCount { get; }
        #region RatingComputation
        public double CurrentRating {
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
        #endregion

        #region Constructor
        public GameAccount(string aUserName, string uOpponent, double point)
        {
            UserName = aUserName;
            BasicWinGame(/*opponent*/uOpponent);
        }

        #region GamesDeclaration
        private List<Game> allGames = new List<Game>();
        #endregion
        #region WinGame
        public void BasicWinGame(string uOpponent)
        {
            Random gamepoints = new Random();
            double point = gamepoints.Next(10, 20);
            var basewin = new BasicGame(point, uOpponent);
            basewin.GamePoints(point); 
            allGames.Add(basewin);
        }
        #endregion

        #region LoseGame
        public void BasicLoseGame(string uOpponent)
        {
            Random gamepoints = new Random();
            double point = gamepoints.Next(10, 20);
            var baselose = new BasicGame(-point, uOpponent);
            baselose.GamePoints(point);
            allGames.Add(baselose);
        }
        #endregion

        public void AllinWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            point = CurrentRating;
            var allinwin = new AllinGame(point, uOpponent);
            allGames.Add(allinwin);
        }


        public void AllinLoseGame(string uOpponent, double point)
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

        public void ArcadeWinGame(string uOpponent, double point)
        {
            if (point < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Amount of deposit must be positive");
            }
            var arcadewin = new ArcadeGame(point, uOpponent);
            allGames.Add(arcadewin);
        }

        public void ArcadeLoseGame(string uOpponent, double point)
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
        #endregion
    }
}
