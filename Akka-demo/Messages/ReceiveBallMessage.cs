namespace Akka_demo.Messages
{
    internal class ReceiveBallMessage
    {
        public ReceiveBallMessage(string playerNumber)
        {
            PlayerNumber = playerNumber;
        }

        public string PlayerNumber { get; }
    }
}