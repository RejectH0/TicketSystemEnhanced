using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;
using TicketSystemEnhanced.Controllers;
using TicketSystemEnhanced.Models;
using TicketSystemEnhanced.Views;

namespace TicketSystemEnhanced
{
    // Version 2.04 // 01MAR2020 1950 // STUCK: ListController, Line 39: How to find instance of BugTicket?

    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public Program()
        {
            Logger.Debug("Program Started");
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