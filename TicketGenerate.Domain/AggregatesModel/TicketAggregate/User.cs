using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Domain.SeedWork;

namespace TicketGenerate.Domain.AggregatesModel.TicketAggregate
{
    public class User : ValueObject
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string FullName => $"{Fname} {Lname}";

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public DateTime MembershipDate { get; set; }

        public User() { }

        public User(int id, string fname, string lname, string username, string password, string role, DateTime membershipDate)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            Username = username;
            Password = password;
            Role = role;
            MembershipDate = membershipDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Fname;
            yield return Lname;
            yield return Username;
            yield return Password;
            yield return Role;
            yield return MembershipDate;
        }
    }
}
