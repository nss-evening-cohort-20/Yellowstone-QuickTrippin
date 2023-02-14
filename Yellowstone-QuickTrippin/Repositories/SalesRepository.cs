using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin.Repositories;

public class SalesRepository
{

    static List<Sales> _sales = new List<Sales>()
    {
        new Sales(518, 1333.00, 87984.58, 4975.69, 68951.00)
    };

    public List<Sales> GetSales()
    {
        return _sales;
    }

    public void AddSales(Sales NewSale)
    {
        _sales.Add(NewSale);
    }


}
