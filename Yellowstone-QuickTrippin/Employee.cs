using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class Employee
{
    public string Name { get; set; }
    public string Role { get; set; }
    public int StoreNumber { get; set; }
    public string JobType { get; set; }
    public decimal Sales { get; set; }


    public Employee(string name, string role, int storeNumber, decimal sales, string jobTitle)
    {
        Name = name;
        StoreNumber = storeNumber;
        Role = role;
        JobType = jobTitle;
        Sales = sales;

    }
    
}

