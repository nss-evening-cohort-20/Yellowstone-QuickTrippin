using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yellowstone_QuickTrippin.Repositories;

public class DistrictRepository
{
    // we're using a static list here instead of a proper database
    // but the general idea still holds up once we cover databases
    // it's just another piece of code to replace and refactor nbd

    static List<District> _districts = new List<District>()
    {
        new District(1, "Talledega", new List<Store>{})
    };

    public List<District> GetDistricts()
    {
        return _districts;
    }

    public static void SaveNewDistrict(District district)
    {
        _districts.Add(district);
    }

}
