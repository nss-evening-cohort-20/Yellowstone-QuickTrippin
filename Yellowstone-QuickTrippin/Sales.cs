using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class Sales
{
    public int StoreNumber { get; set; }
    public double? GasYearly { get; set; }
    public double? GasCurrentQuarter { get; set; }
    public double? RetailYearly { get; set; }
    public double? RetailCurrentQuarter { get; set; }

    public Sales(int storeNumber, double gasYearly, double gasCurrentQuarter, double retailYearly, double retailCurrentQuarter)
    {
        StoreNumber = storeNumber;
        GasYearly = gasYearly;
        GasCurrentQuarter = gasCurrentQuarter;
        RetailYearly = retailYearly;
        RetailCurrentQuarter = retailCurrentQuarter;
    }

}
