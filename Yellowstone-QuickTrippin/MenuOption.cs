using System.Runtime.Serialization;
using Yellowstone_QuickTrippin;

namespace Yellowstone_QuickTrippin
{
    [DataContract]
    public enum MenuOption
    {
        None = 0,
        [EnumMember(Value ="Enter District Sales")]
        EnterDistrictSales = 1,
        [EnumMember(Value = "Generate District Report")]
        GenerateDistricReport = 2,
        [EnumMember(Value = "Add New Employee")]
        AddNewEmployee = 3,
        [EnumMember(Value = "Add Store/District")]
        AddStoreOrDistrict = 4,
        Exit = 5,
    }
        
}

