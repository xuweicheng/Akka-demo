using Akka.Actor;
using Akka_demo.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akka_demo.Actors
{
    public class AnalystActor : ReceiveActor
    {
        private int _passCount;

        public AnalystActor()
        {
            _passCount = 0;
            Receive<IncrementPassCountMessage>(m => 
            {
                _passCount++;
                Console.WriteLine($"Number of passes so far {_passCount}");
                });
        }

    }
}
