using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemEnhanced.Models
{
    public class TaskTicket : Ticket
    {
        public TaskTicket(string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public TaskTicket(string summary, string status, string priority, Person submitter, Person assigned, List<Person> watching, string projectName, string dueDate) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

    }
}
