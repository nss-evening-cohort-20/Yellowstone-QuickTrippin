using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class Store
{
    public int StoreNumber { get; set; }
    public int DistrictNumber { get; set; }

    public Store(int storeNumber, int districtNumber)
    {
        StoreNumber = storeNumber;
        DistrictNumber = districtNumber;
    }

}
