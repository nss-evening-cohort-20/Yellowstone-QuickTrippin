using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin.Repositories;

public class StoreRepository
{

    static List<Store> _stores = new List<Store>()
    {
        new Store(518, 10376.48, 56432.13, 86461.53, 48635.44),
    new Store(517, 10376.48, 56432.13, 86461.53, 48635.44)
    };

    public List<Store> GetStores()
    {
        return _stores;
    }


}
