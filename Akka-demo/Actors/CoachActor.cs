using Akka.Actor;
using Akka_demo.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akka_demo.Actors
{
    public class CoachActor : ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> _players;

        public CoachActor()
        {
            _players = new Dictionary<string, IActorRef>();

            Receive<KickBallOutMessage>(m =>
            {
                CreatePlayerIfNotExist(m.PlayerNumber);

                IActorRef playerActorRef = _players[m.PlayerNumber];

                playerActorRef.Tell(m);
            });

            Receive<ReceiveBallMessage>(m => {
                CreatePlayerIfNotExist(m.PlayerNumber);

                IActorRef playerActorRef = _players[m.PlayerNumber];

                playerActorRef.Tell(m);
            });
        }

        private void CreatePlayerIfNotExist(string playerNumber)
        {
            if (!_players.ContainsKey(playerNumber))
            {
                _players[playerNumber] = Context.ActorOf(Props.Create(() => new PlayerActor(playerNumber)), $"Player{playerNumber}");

                Console.WriteLine($"CoachActor created Player{playerNumber}, (Total Users:{_players.Count})");
            }
        }

        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("CoachActor Prestart");
        }

        protected override void PostStop()
        {
            base.PostStop();
            Console.WriteLine("CoachActor PostStop");
        }
    }
}
