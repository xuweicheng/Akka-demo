using Akka.Actor;
using Akka_demo.Actors;
using Akka_demo.Messages;
using System;

namespace Akka_demo
{
    class Program
    {
        private static ActorSystem MySoccerGame;
        static void Main(string[] args)
        {
            MySoccerGame = ActorSystem.Create("SoccerGame");

            MySoccerGame.ActorOf<GameActor>("Game");

            Console.WriteLine("Start the game by receive command, as ref pass the ball a player");
            Console.WriteLine("Please enter a command: kick,1 or receive,1");
            do
            {
                var command = Console.ReadLine();
                var commandParams = command.Split(",");
                var action = commandParams[0];
                var playerNumber = commandParams.Length == 2 ? commandParams[1] : "" ;

                if (action == "kick")
                {
                    var kickBallMessage = new KickBallOutMessage(playerNumber);
                    MySoccerGame.ActorSelection("/user/Game/Coach").Tell(kickBallMessage);
                }

                if (action == "receive")
                {
                    var receiveBallMessage = new ReceiveBallMessage(playerNumber);
                    MySoccerGame.ActorSelection("/user/Game/Coach").Tell(receiveBallMessage);
                }

                if(action == "exit")
                {
                    MySoccerGame.Terminate();
                    Environment.Exit(1);
                }

            } while (true);
        }
    }
}
