using Akka.Actor;
using Akka_demo.Messages;
using System;

namespace Akka_demo.Actors
{
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<MyMessage>(m => HandleMyMessage(m));
        }

        private void HandleMyMessage(MyMessage m)
        {
            Console.WriteLine($"{m.Id}:{m.Name}");
        }

        protected override void PreStart()
        {
            Console.WriteLine("EchoActor Prestart");
        }

        protected override void PostStop()
        {
            Console.WriteLine("EchoActor Poststop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("EchoActor PreRestart");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("EchoActor PostRestart");
            base.PostRestart(reason);
        }
    }
}
