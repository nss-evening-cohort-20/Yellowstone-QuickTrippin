using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class District
{
    public int DistrictNumber { get; set; }
    public string DistrictName { get; set; }
    public List<Store> StoreList { get; set; }



    public District(int districtNumber, string districtName, List<Store> storeList)
    {
        DistrictNumber = districtNumber;
        DistrictName = districtName;
        StoreList = storeList;
    }
}
