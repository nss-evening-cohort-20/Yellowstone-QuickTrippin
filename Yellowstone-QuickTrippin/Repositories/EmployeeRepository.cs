using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yellowstone_QuickTrippin;

namespace Yellowstone_QuickTrippin.Repositories
{
    public class EmployeeRepository
    {
        static List<Employees> _employee = new List<Employees>();

        public List<Employees> GetEmployees()
        {
            return _employee;
        }

        public void AddEmployee(Employees NewEmployee)
        {
            _employee.Add(NewEmployee);
        }

    }
}