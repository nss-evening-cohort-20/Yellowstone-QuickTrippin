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
                .AddChoices(new[] {
                "Enter District Sales",
                "Generate District Report",
                "Add New Employee",
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
        Console.WriteLine("We're adding an employee");
        Console.WriteLine("What is their name? Choose wisely and then press enter.");
        string name = Console.ReadLine();
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


            //switch (Console.ReadLine())
            //                {
            //    case "1":
            //        role = JobType.DistrictManager.ToString();
            //        Console.WriteLine(role);
            //        break;
            //    case "2":
            //        role = JobType.StoreManager.ToString();
            //        Console.WriteLine(role);

            //        break;
            //    case "3":
            //        role = JobType.AssistantManager.ToString();
            //        Console.WriteLine(role);

            //        break;
            //    case "4":
            //        role = JobType.Associate.ToString();
            //        Console.WriteLine(role);

            //        break;
            //    default:
            //        Console.WriteLine("That is not a valid answer!");
            //        break;

            //}

            //List<int> storeNums = new List<int>();

            //foreach (var store in _storeRepo.GetStores())
            //{
            //    storeNums.Add(store.StoreNumber);
            //}

            //var str = String.Join(",", storeNums);
            //Console.WriteLine(str);

            var prompt = new TextPrompt<int>("What store are they at?");


            foreach (var store in _storeRepo.GetStores())
            {
                prompt.AddChoices(new[] { store.StoreNumber });
            }

            Console.WriteLine("*Note: If the employee's store is not listed please go back to the Main Menu to first add the store.");
            Console.WriteLine($"Avalible stores:");
            foreach (var store in _storeRepo.GetStores()) 
            {
                Console.WriteLine($"#{store.StoreNumber}");
            }
            Console.WriteLine();
            var NewSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(new[] {
                        "Enter Store Number",
                        "Go home",
        }));
            switch (NewSelection)
            {
                case "Enter Store Number":
                    var selectedStore = AnsiConsole.Prompt(prompt);
                    Console.WriteLine($@" This has been saved successfully!
{name} is a {selection} that works at store #{selectedStore}");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return back to the Main Menu.");
                    Console.ReadKey();

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
            case "Go home":
                Run();
                break;
            default:
                Console.WriteLine("That is not a valid answer!");
                break;
        }
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

        Store newStore = new Store(storeNumber, 1);

        StoreRepository.AddStore(newStore);
        Console.Clear();
        Console.WriteLine($"Store #{storeNumber} has been added to the list!\n");
        Console.WriteLine("Press any key to return back to the Main Menu.");
        Console.ReadKey();
    }
    public void GetDistrictReport()
    {

        foreach (var store in _storeRepo.GetStores())
        {
            foreach (var district in _districtRepository.GetDistricts())
            {
                if (store.DistrictNumber == district.DistrictNumber)
                {
                    Console.WriteLine($"{district.DistrictName}: {store.StoreNumber}");
                    district.StoreList.Add(store);
                }
            }
        }

        Console.ReadLine();
    }


}
