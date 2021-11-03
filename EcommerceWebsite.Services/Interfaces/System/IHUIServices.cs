using EcommerceWebsite.Utilities.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.System
{
    public interface IHUIServices
    {
        IAsyncEnumerable<HUI> ReadFromTextToList(string fileName);
    }
}
