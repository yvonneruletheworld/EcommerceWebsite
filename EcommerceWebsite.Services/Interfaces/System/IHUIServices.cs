using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.System
{
    public interface IHUIServices
    {
        //Task<bool> SetUpGiaChoHUIItemset();
        Task<bool> ThemHUICosts(List<HUICost> inputs);
        Task<Dictionary<DateTime, List<HUICost>>> GetHUICosts();
        IAsyncEnumerable<HUI> ReadFromTextToList(string fileName);
        Task<Dictionary<string, List<string>>> ModifyListOutput(List<HUI> inputList);
    }
}
