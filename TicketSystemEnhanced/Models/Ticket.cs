using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TicketSystemEnhanced.Models
{
    public abstract class Ticket
    {
        private static int idNext = 1;
        private static int idDestroy = -1;

        public static List<Ticket> tickets = new List<Ticket>();

        protected Ticket(string summary, string status, string priority, string submitter, string assigned,
            string watching)
        {
            if (idDestroy == -1)
            {
                TicketNumber = idNext;
                idNext++;
            }
            else
            {
                TicketNumber = idDestroy;
            }

            Summary = summary;
            Status = status;
            Priority = priority;

            Submitter = Person.AllPeople.Any(item => item.FullName.Equals(submitter)) ? Person.AllPeople.Find(item => item.FullName.Equals(submitter)) : new Person(submitter);

            Assigned = Person.AllPeople.Any(item => item.FullName.Equals(assigned)) ? Person.AllPeople.Find(item => item.FullName.Equals(assigned)) : new Person(assigned);

            Watching = new WatcherList<Person>();
            if (!(watching == null || watching.Equals("none")))
            {
                var personList = watching.Split('|');

                foreach (var t in personList)
                    Watching.Add(Person.AllPeople.Any(item => item.FullName.Equals(t))
                        ? Person.AllPeople.Find(item => item.FullName.Equals(t))
                        : new Person(t));
            }
        }

        protected Ticket(string summary, string status, string priority, Person submitter, Person assigned,
            List<Person> watching)
        {
            if (idDestroy == -1)
            {
                TicketNumber = idNext;
                idNext++;
            }
            else
            {
                TicketNumber = idDestroy;
            }

            this.Summary = summary;
            this.Status = status;
            this.Priority = priority;

            this.Submitter = Person.AllPeople.Find(item => item.Equals(submitter));
            this.Assigned = Person.AllPeople.Find(item => item.Equals(assigned));
            this.Watching = new WatcherList<Person>();
            foreach (var item in watching) this.Watching.Add(item);
        }

        public int TicketNumber { get; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public Person Submitter { get; set; }
        public Person Assigned { get; set; }
        public WatcherList<Person> Watching { get; set; }

        public void Dispose()
        {
            idDestroy = TicketNumber;
        }

        private static void Dump(object o)
        {
            var json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }

        public override string ToString()
        {
            var str = TicketNumber + "," + Summary + "," + Status + "," + Priority + "," + Submitter + "," + Assigned;
            var numWatching = Watching.Count();

            if (numWatching > 0)
            {
                str += ",";

                str += Watching.ToString();
            }

            return str;
        }

        private void LogError(string eMessage, string location)
        {
            Console.WriteLine(eMessage, location);
        }

        public class WatcherList<TPerson> : List<TPerson>
        {
            public override string ToString()
            {
                var str = "";
                var thisCount = this.Count();
                if (thisCount > 1)
                {
                    for (var g = 0; g < thisCount; g++) str += this.ElementAt(g) + "|";

                    return str.Substring(0, str.Length - 1);
                }

                str += this.ElementAt(0);
                return str;
            }
        }
        
    }
}
