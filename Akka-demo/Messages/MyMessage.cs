namespace Akka_demo.Messages
{
    public class MyMessage
    {
        public MyMessage(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; private set; }
        public int Id { get; private set; }
    }
}
