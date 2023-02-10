using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin;

public class StoreRepository
{

    static List<Store> _stores = new List<Store>()
    {
        new Store(518)
    };

    public List<Store> GetStores()
    {
        return _stores;
    }

    public static void AddStore(Store newStore)
    {
        _stores.Add(newStore);
    }


}
