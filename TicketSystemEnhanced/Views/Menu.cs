﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemEnhanced.Models;

namespace TicketSystemEnhanced.Views
{
    public class Menu
    {
        private static int index;

        public void RunMainMenu()
        {
            while (true)
            {
                DisplayHeader();
                var menuMin = 1;
                var menuMax = PrintMainMenu(); // Show the Main Menu

                // Since the MainMenu should always contain < 10 items, we're only going to ask the user for one character
                // of input, and we're going to trap the heck out of it since we should never trust user input.

                Console.Write("[=+> # <+=] Choose ({0}-{1})", menuMin, menuMax); // menu prompt
                Console.SetCursorPosition(5, Console.CursorTop); // Move the cursor to the '#' in the prompt
                var sb = new StringBuilder(); // Stringbuilder object that will hold the user's menu choice
                ConsoleKeyInfo cki; // ConsoleKeyInfo object
                cki = Console.ReadKey(); // Get the input from the user
                sb.Append(cki.KeyChar); // Throw that input into the StringBuilder object so it can be parsed.

                var userChoice = 0;
                try
                {
                    userChoice = int.Parse(sb.ToString());
                }
                catch
                {
                    userChoice = 0;
                }

                switch (userChoice)
                {
                    case 1:
                        ReadFile();
                        break;
                    case 2:
                        CreateTicket();
                        break;
                    case 3:
                        ListAllTickets();
                        break;
                    case 4:
                        ListAllPeople();
                        break;
                    case 5:
                        ExitGracefully();
                        break;
                    case 6:
                        InvalidMenuChoice();
                        break;
                    case 7:
                        InvalidMenuChoice();
                        break;
                    case 8:
                        InvalidMenuChoice();
                        break;
                    case 9:
                        InvalidMenuChoice();
                        break;
                    case 0:
                        InvalidMenuChoice();
                        break;
                    default:
                        InvalidMenuChoice();
                        break;
                }
            }
        }
        private int PrintMainMenu()
        {
            var menuName = "Main";
            string[] menuChoices =
            {
                "Read Ticket File",
                "Create Ticket",
                "List All Tickets",
                "List All People",
                "Exit Program"
            };

            Console.WriteLine(menuName + " Menu");
            for (var i = 0; i < menuChoices.Length; i++) Console.WriteLine(i + 1 + ": " + menuChoices[i]);

            return menuChoices.Count();
        }
        private void DisplayHeader()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (var i = 0; i < Console.WindowWidth; i++) Console.Write("*");

            var winWidth = Console.WindowWidth - 1;
            Console.SetCursorPosition(winWidth, 1);
            Console.Write("*");

            Console.SetCursorPosition(0, 2);
            for (var i = 0; i < Console.WindowWidth; i++) Console.Write("*");

            var menuText = "Welcome to the Gregg Sperling Ticket System!";
            Console.SetCursorPosition(0, 1);
            // ReSharper disable once FormatStringProblem
            Console.WriteLine("{0," + (Console.WindowWidth / 2 + menuText.Length / 2) + "}", menuText);
            Console.SetCursorPosition(0, 1);
            Console.Write("*");
            Console.SetCursorPosition(0, 5);
        }
        private void CreateTicket()
        {
            var summarySelection = new List<string>
            {
                "Bug/Defect",
                "Enhancement",
                "Task"
            };

            var prioritySelection = new List<string>
            {
                "Low",
                "Routine",
                "Priority",
                "Emergency"
            };

            DisplayHeader();
            Console.SetCursorPosition(0, 6);
            var menuText = "-=+> Create Ticket <+=-";
            Console.SetCursorPosition(0, 6);
            // ReSharper disable once FormatStringProblem
            Console.WriteLine("{0," + (Console.WindowWidth / 2 + menuText.Length / 2) + "}", menuText);
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Please choose Ticket Priority:");

            var ticketPriority = MenuItemSelection(prioritySelection);
            Console.SetCursorPosition(75, 7);
            var ticketStatus = "New";
            Console.WriteLine("Ticket Status   : {0}", ticketStatus);
            Console.SetCursorPosition(75, 8);
            Console.WriteLine("Ticket Priority : {0}", ticketPriority);
            Console.SetCursorPosition(0, 7);
            ConsoleSpaces(50, 10);
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Please choose Summary Selection:");
            var ticketSummary = MenuItemSelection(summarySelection);
            Console.SetCursorPosition(75, 9);
            Console.WriteLine("Ticket Summary  : {0}", ticketSummary);
            Console.SetCursorPosition(0, 7);
            ConsoleSpaces(50, 10);
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Who is submitting this ticket?");
            var ticketSubmitter = MenuItemPersonSelection();
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Ticket Submitter: {0}", ticketSubmitter);
            Console.SetCursorPosition(0, 7);
            ConsoleSpaces(50, 10);
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Please assign this ticket: ");
            var ticketAssigned = MenuItemPersonSelection();
            Console.SetCursorPosition(75, 11);
            Console.WriteLine("Ticket Assigned : {0}", ticketAssigned);

            ConsoleKey userResponse;
            //string Key;
            var watchers = new List<Person>();

            do
            {
                Console.SetCursorPosition(0, 7);
                ConsoleSpaces(60, 10);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Please choose who will watch this ticket:");
                var watcher = MenuItemPersonSelection();
                watchers.Add(watcher);
                Console.SetCursorPosition(75, 11 + watchers.Count());
                Console.WriteLine("Watcher #{0}: {1}", watchers.Count(), watcher);
                Console.SetCursorPosition(0, 7);
                ConsoleSpaces(60, 20);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Would you like to add another Watcher? (Y/N): ");
                userResponse = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, 7);
                ConsoleSpaces(60, 20);
            } while (userResponse == ConsoleKey.Y);

            tickets.Add(new Ticket(ticketSummary, ticketStatus, ticketPriority, ticketSubmitter, ticketAssigned,
                watchers));
            Console.SetCursorPosition(10, 5);
            PressEnterToContinue();
        }

        private void ConsoleSpaces(int spaces, int lines)
        {
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;


            for (var i = 0; i < lines; i++)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop + i);
                for (var g = 0; g < spaces; g++) Console.Write(" ");
            }
        }

        private Person MenuItemPersonSelection()
        {
            index = 0;
            var str = "";
            Console.CursorVisible = false;
            var people = new List<string>();
            people.Add("[New]");

            foreach (var item in Person.AllPeople) people.Add(item.FullName);

            while (str.Length == 0) str = drawMenu(people, Console.CursorLeft, Console.CursorTop);

            Console.CursorVisible = true;

            if (str.Equals("[New]"))
            {
                Console.SetCursorPosition(10, 5);
                var newName = getStringValue("Please enter the person's Full Name");
                Console.SetCursorPosition(10, 5);
                ConsoleSpaces(70, 2);
                new Person(newName);
                return Person.AllPeople.Find(item => item.FullName.Equals(newName));
            }

            return Person.AllPeople.Find(item => item.FullName.Equals(str));
        }

        private string MenuItemSelection(List<string> menuItems)
        {
            index = 0;
            var str = "";

            Console.CursorVisible = false;
            while (str.Length == 0) str = drawMenu(menuItems, Console.CursorLeft, Console.CursorTop);

            Console.CursorVisible = true;
            return str;
        }

        private string drawMenu(List<string> items, int cursorLeft, int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            for (var g = 0; g < items.Count; g++)
            {
                if (g == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[g]);
                }
                else
                {
                    Console.WriteLine(items[g]);
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            var ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    index = 0;
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    index++;
                }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    index = items.Count - 1;
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    index--;
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }

            return "";
        }

        private void ListAllTickets()
        {
            DisplayHeader();

            Console.Write("{0,-10}{1,-25}{2,-10}{3,-10}{4,-15}{5,-15}{6,-20}\n", "TicketID", "Summary", "Status",
                "Priority", "Submitter", "Assigned", "Watching");

            var ticketsCount = tickets.Count();
            for (var g = 0; g < ticketsCount; g++)
            {
                var isEmpty = !tickets[g].Watching.Any();
                if (isEmpty)
                    Console.Write("{0,-10}{1,-25}{2,-10}{3,-10}{4,-15}{5,-15}{6,-30}\n", tickets[g].TicketNumber,
                        tickets[g].Summary, tickets[g].Status, tickets[g].Priority, tickets[g].Submitter,
                        tickets[g].Assigned, "none");
                else
                    Console.Write("{0,-10}{1,-25}{2,-10}{3,-10}{4,-15}{5,-15}{6,-30}\n", tickets[g].TicketNumber,
                        tickets[g].Summary, tickets[g].Status, tickets[g].Priority, tickets[g].Submitter,
                        tickets[g].Assigned, tickets[g].Watching);
            }

            PressEnterToContinue();
        }

        private void ListAllPeople()
        {
            DisplayHeader();
            Console.Write("{0,-10}{1,-25}{2,-25}{3,-25}\n", "idNumber", "Full Name", "E-Mail", "Phone");
            foreach (var item in Person.AllPeople)
                Console.Write("{0,-10}{1,-25}{2,-25}{3,-25}\n", item.IdNumber, item.FullName, item.Email, item.Phone);

            PressEnterToContinue();
        }

        private void ExitGracefully()
        {
            Console.Clear();
            DisplayHeader();
            Console.WriteLine("Now exiting this application...");
            WriteFile();
            PressEnterToContinue();
            Environment.Exit(0);
        }

        private void InvalidMenuChoice()
        {
            Console.Clear();
            DisplayHeader();
            var invalidChoice = "You have made an invalid selection and therefore must try again.";
            Console.WriteLine("{0,15}", invalidChoice);
            PressEnterToContinue();
        }

        private void PressEnterToContinue()
        {
            Console.Write("Press Enter To Continue: ");
            Console.ReadKey(false);
            Console.WriteLine();
        }

        private string getStringValue(string prompt)
        {
            var str = "";
            while (true)
            {
                Console.Write(prompt != null ? prompt : "Please enter your response");
                Console.Write(": ");
                str = Console.ReadLine();

                if (str.Equals("-99"))
                    ExitGracefully();
                else if (str.Equals(""))
                    Console.WriteLine("Invalid entry. Please try again.");
                else
                    return str;
            }
        }
    }

}
