using Spectre.Console;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using Yellowstone_QuickTrippin.Repositories;
using static System.Formats.Asn1.AsnWriter;


namespace Yellowstone_QuickTrippin;

public class QTApp
{

    private StoreRepository _storeRepo = new StoreRepository();
    private DistrictRepository _districtRepository = new DistrictRepository();
    private SalesRepository _salesRepository = new SalesRepository();
    private EmployeeRepository _employeeRepository = new EmployeeRepository();

    private bool working;
    public void Run()

    {
        working = true;

        while (working)
        {
            Console.Title = "QT-Home";

            AnsiConsole.Write(
                new FigletText("QT-App")
                .LeftJustified()
                .Color(Color.Red));

            var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("QT Actions - use up/down arrows + enter to make a selection")
                .PageSize(10)
                .HighlightStyle("Red")
                .AddChoices(new[] {
                "Enter District Sales",
                "Generate District Report",
                "Add New Employee",
                "View Exsisting Employees",
                "Add Store/District",
                "Exit"
            }));

            switch (selection)
            {
                case "Enter District Sales":
                    Console.Clear();
                    EnterDistrictSale();
                    Console.Clear();
                    break;
                case "Generate District Report":
                    Console.Clear();
                    GetDistrictReport();
                    Console.Clear();
                    break;
                case "Add New Employee":
                    Console.Clear();
                    AddNewEmployee();
                    Console.Clear();
                    break;
                case "View Exsisting Employees":
                    Console.Clear();
                    ViewExsistingEmployees();
                    Console.Clear();
                    break;
                case "Add Store/District":
                    Console.Clear();
                    AddStoreOrDistrict();
                    Console.Clear();
                    break;
                case "Exit":
                    Console.Clear();
                    working = false;
                    break;
            }
        }

        AnsiConsole.Write(
            new FigletText("Goodbye!")
            .Centered()
            .Color(Color.Red));
    }

    public void EnterDistrictSale()
    {
        //Get list of all stores
        Console.Title = "Enter District Sales";
        List<Store> stores = _storeRepo.GetStores();
        SalesRepository SalesRepo = new SalesRepository();

        Console.WriteLine("Enter Store Number");
        Console.Write("#");
        int StoreNumber = Convert.ToInt32(Console.ReadLine());

        //See if store number exists in the _storeRepo
        bool doesExist = (stores.Where(s => s.StoreNumber == StoreNumber)).ToList().Count > 0;

        if (doesExist)
        {

            Console.WriteLine("Please enter in the store sales (Gas Yearly):");
            double UserGasYearly = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter in the store sales (Gas Current Quarter):");
            double UserGasCurrentQuarter = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter in the store sales ( Retail Yearly):");
            double UserRetailYearly = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter in the store sales (Retail Current Quarter):");
            double UserRetailCurrentQuarter = Convert.ToDouble(Console.ReadLine());


            Sales NewSale = new Sales(StoreNumber, UserGasYearly, UserGasCurrentQuarter, UserRetailYearly, UserRetailCurrentQuarter);
            SalesRepo.AddSales(NewSale);
        }
        else
        {
            Console.WriteLine("Store number is invalid. Please enter a valid Store Number");
        }
    }

    public void AddNewEmployee()
    {

        EmployeeRepository EmployeeRepo = new EmployeeRepository();


        Console.WriteLine("We're adding an employee");
        Console.WriteLine("What is their name? Choose wisely and then press enter.");
        string name = Console.ReadLine();
        Console.Clear();
        string role = "";
        bool startLoop = true;
        // ask what store number 
        while (startLoop)
        {
            var selection = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title($"What is {name}'s job title?")
               .PageSize(10)
               .AddChoices(new[] {
                "District Manager",
                "Store Manager",
                "Assistant Manager",
                "Associate",
                }));



            var prompt = new TextPrompt<int>("What store are they at?");

            foreach (var store in _storeRepo.GetStores())
            {
                prompt.AddChoices(new[] { store.StoreNumber });
            }

            Console.WriteLine($"Avalible stores:");

            foreach (var store in _storeRepo.GetStores())
            {
                Console.WriteLine($"#{store.StoreNumber}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*Note: If the employee's store is not listed please go back to the Main Menu to first add the store.");
            Console.WriteLine();
            var NewSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
                        "Enter Store Number",
                        "Go home",
        })
            );


            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            bool isInputCorrect = false;

            switch (NewSelection)
            {
                case "Enter Store Number":
                    var selectedStore = AnsiConsole.Prompt(prompt);
                    Console.WriteLine($"{name} is a {selection} that works at store #{selectedStore}. ");
                    Console.WriteLine();
                    Console.WriteLine($@"Please confirm... 
Name: {name} 
Role: {selection} 
Store number: #{selectedStore}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Is this correct? (y/n)");
                    string confirmation = Console.ReadLine();
                    Console.Clear();

                    if (confirmation == "y")
                    {
                        isInputCorrect = true;
                    }
                    else if (confirmation == "n")
                    {

                        var CorrectedInput = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("What would you like to correct?")
                        .PageSize(10)
                        .AddChoices(new[] {
                        "Name",
                        "Role",
                        "Store Number",
                    })
                        );

                        switch (CorrectedInput)
                        {
                            case "Name":
                                Console.WriteLine("What is the corrected Name?");
                                name = Console.ReadLine();

                                break;
                            case "Role":
                                EditRole();
                                break;
                            case "Store Number":
                                EditStoreNumber();
                                break;

                            default:
                                Console.WriteLine("That is not a valid answer!");
                                break;
                        }

                     ;

                    }
                    Console.WriteLine($"What is {name}'s yearly sales? ");
                    Console.WriteLine("*Please exclude the '$' sign.");
                    Console.WriteLine();
                    var YearlySalesInput = Console.ReadLine();
                    if (decimal.TryParse(YearlySalesInput, out decimal SalesNum))
                    {
                        Console.WriteLine("This has been recorded!");
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid sale.");
                    }
                    Console.WriteLine("Press any key to return back to the Main Menu.");
                    Console.ReadKey();

                    Employee NewEmployee = new Employee(name, selection, selectedStore,  SalesNum, role);
                    EmployeeRepo.AddEmployee(NewEmployee);



                    //Sales NewSale = new Sales(StoreNumber, UserGasYearly, UserGasCurrentQuarter, UserRetailYearly, UserRetailCurrentQuarter);
                    //SalesRepo.AddSales(NewSale);

                    break;
                case "Go home":
                    Console.Clear();
                    Run();
                    break;
                default:
                    Console.WriteLine("That is not a valid answer!");
                    break;
            }
            startLoop = false;
        }


    }

    public void ViewExsistingEmployees()
    {
        List<Employee> employees = _employeeRepository.GetEmployees();
        Console.WriteLine("Exsisting Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine($@"

==================================
Name:{employee.Name}
Title: {employee.Role}
Store Number :{employee.StoreNumber}
Yearly Sales Report:  ${employee.Sales} 
==================================");
        }
        var selection = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
             .Title("What would you like to do?")
             .PageSize(10)
             .AddChoices(new[] {
                       "Go home",

         }));
        //Console.WriteLine("Do you wish to edit data?");
        //var editData = Console.ReadLine();
        //if (editData == "y") 
        //{

        //}

        //Console.ReadLine();
    }
    public void AddStoreOrDistrict()
    {
        var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
                        "Create New Store",
                        "Create New District",
                        "Go home",

        }));

        switch (selection)
        {
            case "Create New Store":
                AddStore();
                break;
            case "Create New District":
                AddDistrict();
                break;
            case "Go home":
                Run();
                break;
            default:
                break;
        }
    }
    public void EditName()
    {
     

    }
    public void EditRole()
    {
        Console.WriteLine("What is the corrected Role?");
        string CorrectedRole = Console.ReadLine();

    }
    public void EditStoreNumber()
    {
        Console.WriteLine("What is the corrected Store Number?");
        string CorrectedStoreNumber = Console.ReadLine();

    }
    public void AddStore()
    {
        Console.Write("Enter New Store Number: ");

        string storeNumberInput = Console.ReadLine();

        int storeNumber;

        if (!int.TryParse(storeNumberInput, out storeNumber))
        {
            Console.WriteLine("Please enter a number");
            Console.Write("Store Number: ");
            storeNumberInput = Console.ReadLine();
        }
        else
        {
            storeNumber = Convert.ToInt32(storeNumberInput);
        }

        var prompt = new TextPrompt<int>("Please specify the relevant district for this store");

        foreach (var district in _districtRepository.GetDistricts())
        {
            prompt.AddChoices(new[] { district.DistrictNumber });
        }

        var selectedDistrict = AnsiConsole.Prompt(prompt);

        Store newStore = new Store(storeNumber, selectedDistrict);

        StoreRepository.AddStore(newStore);
        Console.Clear();
        Console.WriteLine($"Store #{storeNumber} in district #{selectedDistrict} has been added to the list!\n");
        Console.WriteLine("Press any key to return home");
        Console.ReadKey();
    }

    public void AddDistrict()
    {
        Console.WriteLine("The existing districts are listed below.\n");
        foreach (var district in _districtRepository.GetDistricts())
        {
            Console.WriteLine($"{district.DistrictNumber} - {district.DistrictName}");
        }
        Console.WriteLine();
        Console.Write("Enter New District Number: ");
        string districtInput = Console.ReadLine();

        int districtNumber;

        if (!int.TryParse(districtInput, out districtNumber))
        {
            Console.WriteLine("Please enter a number");
            Console.Write("District Number: ");
            districtInput = Console.ReadLine();
        }
        else
        {
            districtNumber = Convert.ToInt32(districtInput);
        }

        Console.Write("Enter New District Name: ");

        string districtName = Console.ReadLine();
        List<Store> stores = new List<Store>();
        District newDistrict = new District(districtNumber, districtName, stores);
        DistrictRepository.SaveNewDistrict(newDistrict);
        Console.Clear();
        Console.WriteLine($"{districtName} has been added to the list!\n");
        Console.WriteLine("Press any key to return home");
        Console.ReadKey();
    }
    public void GetDistrictReport()
    {
        //display list of districts and allow user to select district to print report

        List<District> districts = _districtRepository.GetDistricts();
        List<Sales> salesNumbers = _salesRepository.GetSales();


        Console.WriteLine("Please enter an existing district you would like to see the sales of:");
        int districtInput = Convert.ToInt32(Console.ReadLine());
        bool validDistrict = (districts.Where(d => d.DistrictNumber == districtInput)).ToList().Count > 0;

        while (!validDistrict)
        {
            Console.WriteLine("This is not a valid District, please enter a valid district number.");
            districtInput = Convert.ToInt32(Console.ReadLine());
            validDistrict = (districts.Where(d => d.DistrictNumber == districtInput)).ToList().Count > 0;
        }

        if (validDistrict)
        {
            Console.WriteLine("This is a valid District, generating report...");

            foreach (var store in _storeRepo.GetStores())
            {
                foreach (var sale in salesNumbers)
                {
                    if (store.DistrictNumber == districtInput && store.StoreNumber == sale.StoreNumber)
                    {
                        Console.WriteLine(@$"

========================
Store #{sale.StoreNumber} 
Gas Current Quarter: ${sale.GasCurrentQuarter}
Gas Yearly: ${sale.GasYearly}
Retail Current Quarter: ${sale.RetailCurrentQuarter}
Retail Yearly: ${sale.RetailYearly}
========================


");
                    }
                }
            }
        }
        Console.ReadLine();
    }


}
