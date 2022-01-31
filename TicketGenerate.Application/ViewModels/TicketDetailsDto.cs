using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketGenerate.Application.ViewModels
{
    public class TicketDetailsDto
    {
        public string FullName { get; set; }
        public DateTime PersianCreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
