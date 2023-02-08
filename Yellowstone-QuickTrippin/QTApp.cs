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
    public string InitialSelection { get; set; }

    public void Run()

    {
        Console.WriteLine("QuickTrip Management Systems");
        Console.WriteLine(OptionsText());
        InitialSelection = Console.ReadLine(); //refractor this using the ENUM


        switch (InitialSelection)
        {
            case "1":
                // store sales
                Console.WriteLine("WE'RE STILL WORKING ON THIS");
                break;
            case "2":

                Console.WriteLine("WE'RE STILL WORKING ON THIS");
                break;
            case "3":
                Console.WriteLine("We're adding an employee");
                Console.WriteLine("What is their name? Choose wisely and then press enter.");
                string name = Console.ReadLine();
                string role = "";
                bool startLoop = true;
                // ask what store number 
                while (startLoop)
                {
                    Console.WriteLine($"\n\x1B[4m What is {name}'s job title?\x1B[0m ");
                    Console.WriteLine("1. District Manager");
                    Console.WriteLine("2. Store Manager");
                    Console.WriteLine("3. Assistant Manager");
                    Console.WriteLine("4. Associate");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            role = JobType.DistrictManager.ToString();
                            Console.WriteLine(role);
                            startLoop = false;
                            break;
                        case "2":
                            role = JobType.StoreManager.ToString();
                            Console.WriteLine(role);
                            startLoop = false;
                            break;
                        case "3":
                            role = JobType.AssistantManager.ToString();
                            Console.WriteLine(role);
                            startLoop = false;
                            break;
                        case "4":
                            role = JobType.Associate.ToString();
                            Console.WriteLine(role);
                            startLoop = false;
                            break;
                        default:
                            Console.WriteLine("That is not a valid answer!");
                            break;

                    }
                }

                //var employeeListRepo = new EmployeeRepository();
                //employeeListRepo.Add(new Employee(name, role));
                //var employeeList = employeeListRepo.GetAll();

                //foreach (Employee  e in employeeList)
                //{
                //    Console.WriteLine($"Name:{e.Name} / Job Title: {e.JobType}");
                //}
                break;

            case "4":
                break
                // add a store
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
