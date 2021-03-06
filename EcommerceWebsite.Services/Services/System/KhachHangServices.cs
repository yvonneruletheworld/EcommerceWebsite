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
using EcommerceWebsite.Utilities.Output.System;

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
            return _context.ApplicationUsers.Where(u => u.Email.Equals(email) && !u.IsDeleted)
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

        public async Task<KhachHangOutput> GetKhachHangTheoMa(string maKhachHang)
        {
            return await (from kh in _context.KhachHangs
                          join ap in _context.ApplicationUsers on (kh == null ? string.Empty : kh.MaKhachHang) equals ap.Id
                          where !ap.IsDeleted && kh.MaKhachHang == maKhachHang
                          select new KhachHangOutput
                            {
                                TenKhachHang = kh.HoTen,
                                Email = ap.Email,
                                GioiTinh = kh.GioiTinh
                            }).FirstOrDefaultAsync();
        }

        public async Task<Dictionary<string, ApplicationUser>> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await GetKhachHangTheoEmail(usernameOrEmail);
            user ??= await GetKhachHangTheoUsername(usernameOrEmail);

            var result = new Dictionary<string, ApplicationUser>();
            if(user ==  null)
            {
                result.Add("NotRegister", user);
            }    
            if (string.IsNullOrEmpty(password) || !(await CheckLoginPass(user,password)  ))
            {
                result.Add("PasswordIncorrect", user);
            }
            if (user.Status == Data.Enum.Status.InActive)
            {
                result.Add("UserInactive", user);
            }
            else
                result.Add("Success", user);

            return result;
        }



        //public Task<Dictionary<string, KhachHang>> LoginAsync(string usernameOrPhone, string pass)
        //{
        //    var result = new Dictionary<string, KhachHang>();
        //    var obj = await 
        //}
    }
}
