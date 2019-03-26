using Akka.Actor;
using Akka_demo.Messages;
using System;

namespace Akka_demo.Actors
{
    public class PlayerActor : ReceiveActor
    {
        private string _ball;

        public string PlayerNumber { get; }

        public PlayerActor(string playerNumber)
        {
            OpenPosition();
            _ball = "a ball";
            PlayerNumber = playerNumber;
        }

        void OpenPosition() {
            Receive<ReceiveBallMessage>(m => ReceiveBall(m));
            Receive<KickBallOutMessage>(m => Console.WriteLine($"Error: Player{PlayerNumber} do not have a ball to kick."));
        }
        void BallInControl() {
            Receive<ReceiveBallMessage>(m => Console.WriteLine($"Error: Player{PlayerNumber} already received ball."));
            Receive<KickBallOutMessage>(m => KickBall(m));
        }

        private void KickBall(KickBallOutMessage m)
        {
            _ball = null;
            Become(OpenPosition);
            Console.WriteLine($"Player{PlayerNumber} kicked the ball out.");
        }

        private void ReceiveBall(ReceiveBallMessage m)
        {
            _ball = "a ball";
            Become(BallInControl);
            Context.ActorSelection("/user/Game/Analyst").Tell(new IncrementPassCountMessage());
            Console.WriteLine($"Player{PlayerNumber} received the ball.");
        }

    }
}