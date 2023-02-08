using System.Data;
using Yellowstone_QuickTrippin;




Console.Title = "QuikTrip Management Systems";
QTApp app = new QTApp();
app.Run();


switch ();
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
            break;
}