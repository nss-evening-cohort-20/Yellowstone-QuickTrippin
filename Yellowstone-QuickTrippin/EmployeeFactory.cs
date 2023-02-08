using Yellowstone_QuickTrippin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin
{
    internal class EmployeeFactory
    {
        public Employee BuildNewEmployee()
        {
            var question1 = "Enter Employee name(leave blank to end):";
            Console.WriteLine(question1);
            var name = Console.ReadLine();

            if (name == "")
            {
                return new Employee("", "", 0);
            }
            var question2 = $"Enter {name}'s Title:";
            Console.WriteLine(question2);
            var title = Console.ReadLine();

            bool successful = false;
            decimal parsedSales = 0;

            while (!successful)
            {
                Console.WriteLine($"Enter {name}'s retail sales");
                var retailSales = Console.ReadLine();
                successful = decimal.TryParse(retailSales, out parsedSales);
            }
            var retVal = new Employee(name, title, parsedSales);
            return retVal;

        }

    }
}


// build new employee
// add employee to storeTeam list 