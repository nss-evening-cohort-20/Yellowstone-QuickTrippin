using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class SalesRepository
{

    static List<Sales> _sales = new List<Sales>();

    public List<Sales> GetSales()
    {
        return _sales;
    }

    public void AddSales(Sales NewSale)
    {
        _sales.Add(NewSale);
    }


}
