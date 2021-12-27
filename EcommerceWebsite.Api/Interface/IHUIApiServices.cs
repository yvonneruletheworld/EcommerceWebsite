using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.Output.System;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
    public  interface IHUIApiServices
    {
        Task<bool> SuaGiaHui(string maHUI, decimal giaMoi, string comboCode,string ngayTao);
        Task<List<HUI>> GetListHUIFromOutput(string url);
        Task<List<DoanhThuOutput>> GetListHUIForInput();
        Task<HUIDetailVM> GetHuiDetail(string comboCode, DateTime ngayTao, DateTime ngayNhapKe);
        Task<Dictionary<DateTime, List<HUICost>>> GetListHUIFromData();
        Task<bool> AddListHui(List<HUI> inputs);
    }
}
