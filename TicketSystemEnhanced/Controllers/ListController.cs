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

        public int NewBugTicket(string ticketSummary, string ticketStatus, string ticketPriority, Person ticketSubmitter, Person ticketAssigned, List<Person> watchers)
        {
            BugTicket bugTicket = new BugTicket(ticketSummary, ticketStatus, ticketPriority, ticketSubmitter, ticketAssigned, watchers);
            BugTickets.Add(bugTicket);
            return bugTicket.ReturnTicketNumber();
        }
        public int NewEnhanceTicket(string ticketSummary, string ticketStatus, string ticketPriority, Person ticketSubmitter, Person ticketAssigned, List<Person> watchers)
        {
            EnhanceTicket enhanceTicket = new EnhanceTicket(ticketSummary, ticketStatus, ticketPriority, ticketSubmitter, ticketAssigned, watchers);
            EnhanceTickets.Add(enhanceTicket);
            return enhanceTicket.ReturnTicketNumber();
        }

        public int NewTaskTicket(string ticketSummary, string ticketStatus, string ticketPriority, Person ticketSubmitter, Person ticketAssigned, List<Person> watchers)
        {
            TaskTicket taskTicket = new TaskTicket(ticketSummary, ticketStatus, ticketPriority, ticketSubmitter, ticketAssigned, watchers);
            TaskTickets.Add(taskTicket);
            return taskTicket.ReturnTicketNumber();
        }

    }
}
