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
    public void Run()
    {
        Console.WriteLine("QuickTrip Management Systems");
        Console.WriteLine(OptionsText());
        Console.ReadLine();
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
