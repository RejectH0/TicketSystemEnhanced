using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TicketSystemEnhanced.Controllers;
using TicketSystemEnhanced.Models;
using TicketSystemEnhanced.Views;

namespace TicketSystemEnhanced
{
    // Version 2.02 // 01MAR2020 1715 // Models, Views, Controllers has been broken out, code is completely refactored.

    internal class Program
    {
        public Program()
        {
            List<BugTicket> bugTickets = new List<BugTicket>();
            List<EnhanceTicket> enhanceTickets = new List<EnhanceTicket>();
            List<TaskTicket> taskTickets = new List<TaskTicket>();
            ListController listController = new ListController(bugTickets, enhanceTickets, taskTickets);

            var menu = new Menu(listController);
            menu.RunMainMenu();
        }

        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Program();
        }

        // ReSharper disable once UnusedMember.Local
        private static void Dump(object o)
        {
            var json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}