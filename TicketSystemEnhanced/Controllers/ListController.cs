using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemEnhanced.Models;
using TicketSystemEnhanced.Views;

namespace TicketSystemEnhanced.Controllers
{
    public class ListController
    {
        public List<BugTicket> BugTickets { get; set; }
        public List<EnhanceTicket> EnhanceTickets { get; set; }
        public List<TaskTicket> TaskTickets { get; set; }
        
        public ListController(List<BugTicket> bugTickets, List<EnhanceTicket> enhanceTickets, List<TaskTicket> taskTickets)
        {
            this.BugTickets = bugTickets;
            this.EnhanceTickets = enhanceTickets;
            this.TaskTickets = taskTickets;
        }


    }
}
