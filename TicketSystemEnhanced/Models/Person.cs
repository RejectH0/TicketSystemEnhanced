using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemEnhanced.Models
{
    public class Person
    {
        private static int _idNext = 1;
        private static int _idDestroy = -1;
        public static List<Person> AllPeople = new List<Person>();

        public Person(string fullName)
        {
            if (_idDestroy == -1)
            {
                IdNumber = _idNext;
                _idNext++;
            }
            else
            {
                IdNumber = _idDestroy;
            }

            this.FullName = fullName;
            Email = "null";
            Phone = "null";

            AllPeople.Add(this);
        }

        public int IdNumber { get; }
        public string FullName { get; set; }
        public string Email { get; }
        public string Phone { get; }

        public void Dispose()
        {
            _idDestroy = IdNumber;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
