using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akka_demo.Actors
{
    public class GameActor : ReceiveActor
    {
        public GameActor()
        {
            Context.ActorOf<CoachActor>("Coach");
            Context.ActorOf<AnalystActor>("Analyst");
        }

        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("GameActor PreStart.");
        }

        protected override void PostStop()
        {
            base.PostStop();
            Console.WriteLine("GameActor PostStop");
        }
    }
}
