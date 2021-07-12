using System;

namespace ConsoleAppTask1.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public DateTime DateUpdated { get; set; }

        public override string ToString()
        {
            return $"Message: Id: {Id}, Data: {Data}, Date: {DateUpdated.ToShortDateString()}";
        }
    }
}
