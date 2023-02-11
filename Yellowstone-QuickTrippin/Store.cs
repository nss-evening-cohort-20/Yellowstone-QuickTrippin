using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class Store
{
    public int StoreNumber { get; set; }

    // These options are not needed for the store object

    // -------------------------------
    public double? GasYearly { get; set; }
    public double? GasCurrentQuarter { get; set; }
    public double? RetailYearly { get; set; }
    public double? RetailCurrentQuarter { get; set; }
    public int DistrictNumber { get; set; }

    // -------------------------------

    public Store(int storeNumber, double gasYearly, double gasCurrentQuarter, double retailYearly, double retailCurrentQuarter, int districtNumber)
    {
        StoreNumber = storeNumber;
        GasYearly = gasYearly;
        GasCurrentQuarter = gasCurrentQuarter;
        RetailYearly = retailYearly;
        RetailCurrentQuarter = retailCurrentQuarter;
        DistrictNumber = districtNumber;
    }

}
