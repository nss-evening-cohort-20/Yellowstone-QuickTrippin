using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class QTApp
{
    private StoreRepository _storeRepo = new StoreRepository();
    public void Run()
    {
        var Choice = 0;
        
        Console.WriteLine("QuickTrip Management Systems");
        Console.WriteLine(OptionsText());
        //Console.WriteLine(_storeRepo.GetStores()[0].StoreNumber);
        Choice = Convert.ToInt16(Console.ReadLine());


        switch (Choice)
        {
            case (int)MenuOption.EnterDistrictSales:
                EnterDistrictSale();
                break;
            case (int)MenuOption.GenerateDistricReport:
                break;
            case (int)MenuOption.AddNewEmployee:
                break;
            case (int)MenuOption.AddStoreOrDistrict:
                break;
            case (int)MenuOption.Exit:
                break;
        }

    }


    public void EnterDistrictSale()
    {
        //Get list of all stores
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

    private string OptionsText()
    {
        StringBuilder builder = new StringBuilder();

        foreach (var option in Enum.GetValues<MenuOption>())
        {
            builder.AppendLine($" {(int)option}. {GetDescriptionFromEnum(option)}");
        }

        return builder.ToString();
    }

    public static string GetDescriptionFromEnum(Enum value)
    {
        var attribute = value.GetType()
        .GetField(value.ToString())
        .GetCustomAttributes(typeof(EnumMemberAttribute), false)
        .SingleOrDefault() as EnumMemberAttribute;
        return attribute == null ? value.ToString() : attribute.Value;
    }

}
