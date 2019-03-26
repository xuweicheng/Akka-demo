namespace Akka_demo.Messages
{
    internal class KickBallOutMessage
    {
        public KickBallOutMessage(string playerNumber)
        {
            PlayerNumber = playerNumber;
        }

        public string PlayerNumber { get; }
    }
}