using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemEnhanced.Models
{
    public class EnhanceTicket : Ticket
    {
        public string Software { get; set; }
        public string Cost { get; set; }
        public string Reason { get; set; }
        public string Estimate { get; set; }

        public EnhanceTicket(string summary, string status, string priority, string submitter, string assigned, string watching) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public EnhanceTicket(string summary, string status, string priority, Person submitter, Person assigned, List<Person> watching) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public int ReturnTicketNumber()
        {
            return this.TicketNumber;
        }

    }
}
