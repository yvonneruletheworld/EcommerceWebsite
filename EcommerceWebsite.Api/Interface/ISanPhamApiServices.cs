using EcommerceWebsite.Application.Pagination;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Interface
{
   public interface ISanPhamApiServices
    {
        Task<PageResponse<List<SanPhamOutput>>> laySanPham(PaginationFilter pagination);

        Task<List<SanPhamNhapOutput>> LaySoLuongNhapVaBan(string maSanPham);
        Task<List<SanPhamVM>> laySanPham2();
        Task<List<SanPhamVM>> LaySPYeuThichKH(string maKH);
        Task<bool> ThemSanPham(SanPhamOutput input);
        Task<bool> ThemPhieuNhap(PhieuNhapInput input);
        Task<bool> Modify(bool laXoa, SanPhamOutput input);
        Task<SanPhamVM> LayViewSanPham(string prdId);
        Task<List<SanPhamVM>> GetViewWithMultipleIds(string[] prdIds, string comboCode);
        Task<SanPhamOutput> LayChiTietSanPham(string prdId);

        Task<List<SanPhamOutput>> laySanPhamTheoHang(string prdId);

        Task<List<SanPhamOutput>> laySanPhamTheoDanhMuc(string prdId);

        Task<List<SanPhamOutput>> timKiemSanPhamTheoTen(string keyword);

        Task<SanPhamVM> laySanPhamTheoMa(string prdId);

        Task<List<SanPhamVM>> LaySanPhamMoiNhat();

        Task<List<ThuocTinh>> layDinhluong();
    }
}
