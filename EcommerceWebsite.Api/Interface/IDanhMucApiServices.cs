using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public interface IDanhMucApiServices
    {
        Task<List<DanhMucOutput>> GetCategories();
        Task<List<CategorySetVM>> GetDanhMucVaSanPhams(int count);
    }
}
