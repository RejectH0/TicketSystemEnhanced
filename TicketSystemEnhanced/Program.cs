using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TicketSystemEnhanced.Views;
using TicketSystemEnhanced.Models;
using TicketSystemEnhanced.Controllers;

namespace TicketSystemEnhanced
{
    // Version 2.00 // 01MAR2020 1645 // Code completely refactored, nothing works and everything is broken.
    
    internal class Program
    {
        public Program()
        {
            Menu menu = new Menu();
            menu.RunMainMenu();
        }

        public static void Main(string[] args)
        {
            new Program();
        }

        private static void Dump(object o)
        {
            var json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }

        
    }
}