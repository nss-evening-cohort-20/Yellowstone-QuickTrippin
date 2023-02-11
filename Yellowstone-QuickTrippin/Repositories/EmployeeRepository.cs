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
        static List<Employee> _employee = new List<Employee>();

        public List<Employee> GetEmployees()
        {
            return _employee;
        }

        public void AddEmployee(Employee NewEmployee)
        {
            _employee.Add(NewEmployee);
        }

    }
}