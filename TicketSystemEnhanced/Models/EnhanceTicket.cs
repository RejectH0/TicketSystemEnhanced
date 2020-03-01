using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemEnhanced.Models
{
    class EnhanceTicket : Ticket
    {
        public EnhanceTicket(string summary, string status, string priority, string submitter, string assigned, string watching, string software, string cost, string reason, string estimate) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public EnhanceTicket(string summary, string status, string priority, Person submitter, Person assigned, List<Person> watching, string software, string cost, string  reason, string estimate) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

    }
}
