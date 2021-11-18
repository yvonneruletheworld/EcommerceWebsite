using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class DanhMucServices : IDanhMucServices
    {
        private readonly EcomWebDbContext _context;
        private readonly ISanPhamServices _sanPhamServices;

        public DanhMucServices(EcomWebDbContext context, ISanPhamServices sanPhamServices)
        {
            _context = context;
            _sanPhamServices = sanPhamServices;
        }

        public async Task<List<DanhMucOutput>> GetDanhMucs()
        {
            try
            {
                var result = await _context.DanhMucs
                    .Where(dm => !dm.DaXoa && dm.HienThiTrangHome == true)
                    .Select( item => new DanhMucOutput {
                        MaDanhMuc = item.MaDanhMuc,
                        TenDanhMuc = item.TenDanhMuc,
                    }).ToListAsync();
                foreach(var item in result)
                {
                    item.DanhMucCon = GetDanhMucConTheoChaAsync(item.MaDanhMuc);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DanhMucOutput> GetDanhMucConTheoChaAsync(string maDanhMuc)
        {
            var lstDM = _context.DanhMucs
                        .Where(x => !x.DaXoa && x.ParentId.Contains(maDanhMuc))
                        .Select(item => new DanhMucOutput
                        {
                            MaDanhMuc = item.MaDanhMuc,
                            TenDanhMuc = item.TenDanhMuc,
                        }).ToList();
            if(lstDM != null && lstDM.Count > 0)
            {
                List<DanhMucOutput> rs = new List<DanhMucOutput>();
                while (lstDM.Any())
                {
                    var prefix = lstDM[0].MaDanhMuc.Split('_')[0].ToString();
                    var subList = lstDM.Where(x => !x.DaXoa && x.MaDanhMuc.Contains(prefix)).ToList();
                    var fist = GetDanhMucAsync(prefix);
                    fist.DanhMucCon = subList;
                    rs.Add(fist);
                    lstDM = lstDM.Skip(subList.Count).ToList();
                }
                return rs;
            }
            return null;
        }

        private DanhMucOutput GetDanhMucAsync(string maDanhMuc)
        {
            return  _context.DanhMucs
                .Where(x => !x.DaXoa && x.MaDanhMuc.Equals(maDanhMuc))
                .Select(item => new DanhMucOutput
                {
                    MaDanhMuc = item.MaDanhMuc,
                    TenDanhMuc = item.TenDanhMuc
                }).FirstOrDefault();
        }

        public async Task<List<CategorySetVM>> GetDanhMucVaSanPhams(int itemCount)
        {
            var rs = new List<CategorySetVM>();
            var lstDM = await _context.DanhMucs
                .Where(dm => !dm.DaXoa && dm.ParentId == null)
                .ToListAsync();
            foreach(var dm in lstDM)
            {
                if (rs.Count > 4)
                    break;
                else
                {
                    var sanPhamTheoDanhMucs = await _sanPhamServices.LaySanPhamTheoLoai(dm.MaDanhMuc, itemCount);
                    if (sanPhamTheoDanhMucs == null || sanPhamTheoDanhMucs.Count == 0)
                        continue;
                    else
                    {
                        var newItem = new CategorySetVM();
                        newItem.TenDanhMuc = dm.TenDanhMuc;
                        newItem.ListSanPham = sanPhamTheoDanhMucs;
                        newItem.ListDanhMucCon = await GetDanhMucCon(dm.MaDanhMuc);
                        rs.Add(newItem);
                    }
                }    
            }
            return rs;
        }

        public async Task<List<DanhMucOutput>> GetDanhMucCon(string parentId)
        {
            return await _context.DanhMucs.Where(dm => !dm.DaXoa && dm.ParentId == parentId)
                .Select(dm => new DanhMucOutput()
                {
                    TenDanhMuc = dm.TenDanhMuc,
                    MaDanhMuc = dm.MaDanhMuc
                }).ToListAsync();
        }
    }
}
