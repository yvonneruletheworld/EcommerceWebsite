using AutoMapper;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<SanPham, SanPhamOutput>()
            //    .ForMember(op => op.NhanHieu, op => op.MapFrom(sp => sp.MaHang));
            CreateMap<SanPhamOutput, SanPham>()
                .ForMember(sp => sp.MaHang, sp => sp.MapFrom(op => op.NhanHieu))
                .ForMember(sp => sp.MaLoaiSanPham, sp => sp.MapFrom(op => op.MaLoai));

            CreateMap<SanPhamOutput, SanPhamVM>();

            CreateMap<SanPhamInput, SanPhamOutput>()
                .ForMember(op => op.SoLuongTon, op => op.MapFrom(ip => ip.SoLuongNhap));
            //    .ForMember(op => op.BangGia.FirstOrDefault().GiaBan, op => op.MapFrom(ip => ip.GiaNhap))
            //    .ForMember(op => op.SoLuongTon, op => op.MapFrom(ip => ip.SoLuongNhap))
            //    .ForMember(op => op.ListThongSo.FirstOrDefault().MaThuocTinh, op => op.MapFrom(ip => ip.MaThuocTinh))
            //    .ForMember(op => op.ListThongSo.FirstOrDefault().GiaTri, op => op.MapFrom(ip => ip.HinhAnh))
            //    .ForMember(op => op.ListThongSo.FirstOrDefault().DonVi, op => op.MapFrom(ip => ip.TenMauMa))
            //    .ForMember(op => op.ListThongSo.FirstOrDefault().GiaTri, op => op.MapFrom(ip => ip.HinhAnh));

            //CreateMap<SanPhamInput, SanPhamOutput>()
            //    .ForMember(ip => ip.GiaNhap)

            CreateMap<SanPhamOutput, ChiTietNhapSanPham>()
                .ForMember(ct => ct.SoLuong, ct => ct.MapFrom(sp => sp.SoLuongTon))
                .ForMember(ct => ct.MaSanPham, ct => ct.MapFrom(sp => sp.MaSanPham))
                //.ForMember(ct => ct.DonGia, ct => ct.MapFrom(sp => sp.BangGia.FirstOrDefault().GiaBan))
                .ForMember(ct => ct.ThanhTien, ct => ct.MapFrom(sp => sp.ThanhTien));


        }
    }
}
