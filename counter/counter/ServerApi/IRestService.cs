using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace counter
{
    interface IRestService
    {
        Task<List<Food>> GetFoodListAsync();

        Task<UInt32> Register();


    }
}
