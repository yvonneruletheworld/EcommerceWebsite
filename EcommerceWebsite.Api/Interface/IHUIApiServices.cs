using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public  interface IHUIApiServices
    {
        Task<List<HUI>> GetListHUIFromOutput(string url);
    }
}
