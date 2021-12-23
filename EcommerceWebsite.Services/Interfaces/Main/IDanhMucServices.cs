using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Interfaces.Main
{
    public interface IDanhMucServices
    {
        Task<List<DanhMucOutput>> GetDanhMucs();
        Task<List<CategorySetVM>> GetDanhMucVaSanPhams(int itemCount, string maKH);
        Task<List<DanhMucOutput>> GetDanhMucCon(string parentId);
    }
}
