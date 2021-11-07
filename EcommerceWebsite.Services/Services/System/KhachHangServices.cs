using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.System;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EcommerceWebsite.Utilities.Input;
using System.Security.Claims;
using AutoMapper;

namespace EcommerceWebsite.Services.Services.System
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly EcomWebDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public KhachHangServices(EcomWebDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<ThongTinKhachHangInput> GetKhachHangInputTheoSdt(string sdt)
        {
            return await (from au in _context.ApplicationUsers 
                          where !au.IsDeleted && au.PhoneNumber == sdt
                          select new ThongTinKhachHangInput()
                          {
                              TenDangNhap = au.UserName,
                              MatKhau = au.PasswordHash,
                              SDT = au.PhoneNumber
                          } ).FirstOrDefaultAsync();
        }

        public Task<ApplicationUser> GetKhachHangTheoEmail(string email)
        {
            return _context.ApplicationUsers.Where(u => u.Email.Equals(email))
                                            .FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetKhachHangTheoId(string id)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(u => !u.IsDeleted && u.Id.Equals(id));
        }

        public async Task<ApplicationUser> GetKhachHangTheoUsername(string userName)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(kh => !kh.IsDeleted && kh.UserName.Equals(userName));
        }

        public string GetUserEmail(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }

        public string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<bool> CheckLoginPass(ApplicationUser obj, string pwd)
        {
            return await _userManager.CheckPasswordAsync(obj, pwd);
        }


        public async Task<bool> UpdateOTPCode(string id, string otpCode)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                var obj = await GetKhachHangTheoId(id);
                if (obj == null) return false;

                //update OTP code
                obj.OTPCode = otpCode;
                _context.Entry(obj).State = EntityState.Modified;//sửa

                var result = await _context.SaveChangesAsync();//Lưu
                await _context.Database.CommitTransactionAsync();

                return result > 0 ;
            }
            catch (Exception exx)
            {
                throw exx;
            }
        }

        public async Task<bool> SubmitUser(ThongTinKhachHangInput input)
        {
            try
            {
                // bat dau transaction create record
                await _context.Database.BeginTransactionAsync();

                //global var
                var id = Guid.NewGuid().ToString();
                //Them vao AspUser
                var hasher = new PasswordHasher<ApplicationUser>();
                ApplicationUser user = new ApplicationUser()
                {
                    Id = id, // tao ma ngau nhien
                    UserName = input.TenDangNhap,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = input.TenDangNhap,
                    Email = input.Email,
                    Ip = input.Ip,
                    IsDeleted = false,
                };
                user.NormalizedEmail = user.Email.ToUpper();
                user.NormalizedUserName = user.Email.ToUpper();
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, input.MatKhau);

                //them vao bang
                await _context.AddAsync(user);

                var resultUser = await _context.SaveChangesAsync();
                if(resultUser > 0) // them thanh cong
                {
                    //tao mot khach hang
                    KhachHang khachHang = new KhachHang()
                    {
                        MaKhachHang = id,
                        HoTen = input.HoTen,
                        GioiTinh = input.GioiTinh,
                        HinhAnh = input.HinhAnh,
                        NgayTao = user.CreateDate,
                        DaXoa = false
                    };

                    await _context.KhachHangs.AddAsync(khachHang);
                    var resultKhachHang = await _context.SaveChangesAsync();

                    if(resultKhachHang > 0)
                    {
                        //Tao dia chi khach hang
                        DiaChiKhachHang diaChi = new DiaChiKhachHang();
                        diaChi = _mapper.Map<DiaChiKhachHang>(input.DiaChi);
                        //diaChi.MaDiaChi = Guid.NewGuid().ToString();
                        diaChi.DaXoa = false;
                        diaChi.NguoiTao = user.UserName;
                        diaChi.MaKhachHang = user.Id;
                        diaChi.Hoten = khachHang.HoTen;
                        diaChi.SDT = user.PhoneNumber;
                        await _context.DiaChiKhaches.AddAsync(diaChi);

                        var resultDiaChi = await _context.SaveChangesAsync();

                        if (resultDiaChi > 0)
                        {
                            await _context.Database.CommitTransactionAsync();
                            return true;
                        }

                    }

                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //public Task<Dictionary<string, KhachHang>> LoginAsync(string usernameOrPhone, string pass)
        //{
        //    var result = new Dictionary<string, KhachHang>();
        //    var obj = await 
        //}
    }
}
