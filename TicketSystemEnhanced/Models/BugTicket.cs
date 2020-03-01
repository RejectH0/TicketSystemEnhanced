using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace TicketSystemEnhanced.Models
{
    public class BugTicket : Ticket
    {
        public BugTicket(string summary, string status, string priority, string submitter, string assigned, string watching, string severity) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public BugTicket(string summary, string status, string priority, Person submitter, Person assigned, List<Person> watching, string severity) : base(summary, status, priority, submitter, assigned, watching)
        {
        }

        public void ReadFile()
        {
            const string pathWithEnv = @"%USERPROFILE%\Documents\GS Ticket System-Bug Tickets.csv";
            var fileData = Environment.ExpandEnvironmentVariables(pathWithEnv);
            
            if (!File.Exists(fileData))
            {
                tickets.Add(new BugTicket("This is a bug ticket", "Open", "High", "Drew Kjell", "Jane Doe",
                    "Drew Kjell|John Smith|Bill Jones"));
                WriteFile();
            }

            if (File.Exists(fileData))
            {
                var sr = new StreamReader(fileData);

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var list = new List<string>(line.Split(','));

                    // handling for blank lines in the file
                    if (list.Count() == 1) continue;

                    // handling for a blank Watchers field
                    if (list.Count() == 6) list.Add("none");

                    // remember there's a header row!
                    // TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
                    // 1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones
                    if (!list[0].All(char.IsDigit))
                    {
                        // The first field is NOT all digits, therefore this is our Header Row. Let's display it on the console for reasons.
                        Console.Write("{0,-10}{1,-25}{2,-10}{3,-10}{4,-15}{5,-15}{6,25}\n", list.ToArray());
                    }
                    else
                    {
                        // we're actually discarding the ticket's number as saved in the file (list[0]) because the Ticket() 
                        // constructor takes care of all ticket number creation.
                        // if user does not read file first and instead enters new tickets first, reading the file could result
                        // in overwriting or loss of data, so we'll just let the constructor deal with adding the ticket number.
                        // BUT, we'll display the ticket numbers from the file anyway, because why not?
                        Console.Write("{0,-10}{1,-25}{2,-10}{3,-10}{4,-15}{5,-15}{6,25}\n", list.ToArray());
                        tickets.Add(new Ticket(list[1], list[2], list[3], list[4], list[5], list[6]));
                    }
                }

                sr.Close();
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

            PressEnterToContinue();
        }

        public void WriteFile()
        {
            var pathWithEnv = @"%USERPROFILE%\Documents\GS Ticket System-Tickets.txt";
            var fileData = Environment.ExpandEnvironmentVariables(pathWithEnv);
            try
            {
                using (var sw = new StreamWriter(fileData, false)) // bool false = NO append.
                {
                    // CSV Header
                    sw.Write("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching1|Watching2\n");

                    foreach (var ticket in tickets)
                    {
                        var str = ticket.ToString();
                        sw.Write(str + "\n");
                    }

                    sw.Close();
                }
            }
            catch (IOException e)
            {
                Console.Write("The file could not be written: {0}", e.Message);
            }
        }

        
    }
}
