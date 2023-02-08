using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class QTApp
{
    public void Run()
    {
        Console.WriteLine(OptionsText());
        Console.ReadLine();
    }

    private string OptionsText()
    {
        StringBuilder builder = new StringBuilder();

        foreach (var option in Enum.GetValues<MenuOption>())
        {
            builder.AppendLine($" {(int)option}. {Enum.GetName(option)}");
        }

        return builder.ToString();
    }
}
