using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1
{
    class Program
    {
        static void Main(string[] args) 
        {

            string val;
            Console.Write("---------Choose your game account----------\n==PRESS 1 if you want normal account;\n==PRESS 2 if you want account without rating;\n==PRESS 3 if you choose Easy game account;\n Your number is = ");
            val = Console.ReadLine();
            int chooseacc = Convert.ToInt32(val);
            if (chooseacc == 1)
            {
                var acc = new GameAccount("Timoner15", "Silvestor13", 0);
                Console.WriteLine($"Game Account was created with Nickname: {acc.UserName} and your current Rating is {acc.CurrentRating}");
                acc.BasicWinGame("Rak228");
                Console.WriteLine(acc.CurrentRating);
                acc.ArcadeLoseGame("Sergio", 11);
                Console.WriteLine(acc.CurrentRating);
                acc.AllinLoseGame("Thomassss", 9);
                Console.WriteLine(acc.CurrentRating);



                Console.WriteLine(acc.GetStats());



                try
                {
                    var invalidAccount = new GameAccount("Timoner", "Sergio", -30);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }

                try
                {
                    acc.BasicLoseGame("Sergio");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught trying to overdraw");
                    Console.WriteLine(e.ToString());
                }
            }
            else if (chooseacc == 2)
            {
                Console.WriteLine($"Congrats! You choose the None Rating Account! All your matches you will play for 0 rating");
                var noneacc = new NoneRatingAccount("EcoBro1234", "Bot-Thomas", 0);
                Console.WriteLine($"Game Account was created with Nickname: {noneacc.UserName} and you haven't got Rating");

                Console.WriteLine(noneacc.GetStats());




                try
                {
                    var invalidAccount = new NoneRatingAccount("Timoner", "Sergio", 0);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }

                try
                {
                    noneacc.ArcLoseGame("Sergio", 0);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught trying to overdraw");
                    Console.WriteLine(e.ToString());
                }
            }
            else if (chooseacc == 3)
            {
                Console.WriteLine($"Congrats! You choose the Easy Rating Account! Your match rating will double if you win and you will lose only a half of match rating if you lose the match");
                var easyacc = new EasyGameAccount("EasyTim", "Tymofii", 40);
                Console.WriteLine($"Game Account was created with Nickname: {easyacc.UserName} and your current Rating is {easyacc.CurrentRating}");

                easyacc.EasyBasicLoseGame("Sergio", 11);
                Console.WriteLine(easyacc.CurrentRating);


                Console.WriteLine(easyacc.GetStats());



                try
                {
                    var invalidAccount = new EasyGameAccount("Timoner", "Sergio", -30);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }

                try
                {
                    easyacc.EasyBasicLoseGame("Sergio", 200);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught trying to overdraw");
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
}
    