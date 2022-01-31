using System;
using TicketGenerate.Domain.SeedWork;

namespace TicketGenerate.Domain.AggregatesModel.TicketAggregate
{
    public class Ticket : Entity, IAggregateRoot
    {
        public DateTime _creationDate { get;  set; }
        public string _title { get;  set; }
        public string _description { get;  set; }

        public User User { get;  set; }      

        public Ticket() { }

        public Ticket(string title, string description, User user)
        {
            _title = title;
            _description = description;
            _creationDate = DateTime.UtcNow;
            User = user;
        }
    }
}
