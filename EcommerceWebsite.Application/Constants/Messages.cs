﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Constants
{
    public static class Messages
    {
        //KhachHang - NhanVien
        public const string KhachHang_LoiDoDaiTenDangNhap = "Tên đăng nhập có độ dài không hợp lệ";
        public const string KhachHang_TenDangNhapKhongHopLe = "Tên đăng nhập/ Số điện thoại không đúng";
        public const string KhachHang_MatKhauKhongDung = "Mật khẩu không đúng";
        public const string KhachHang_NguoiDungKhongHoatDong = "Người dùng chưa được kích hoạt";
        public const string KhachHang_NguoiDungKhongTonTai = "Người dùng không tồn tại";

        //JSON
        public const string Login_PhoneNumEmpty = "phone-num-is-empty";
        public const string Login_PhoneNumIsNotExist = "phone-num-is-not-exist";
        public const string Login_LoadFormSuccess = "load-form-success";
        public const string Login_LoadFormFailed = "load-form-failed";
        public const string Login_EmailNull = "email-null";

        //OTP
        public const string OTP_Invalid = "otp-invalid";
        public const string OTP_SentSuccess = "otp-sent-success";
        public const string OTP_SentFailed = "otp-sent-failed";
        public const string OTP_ServerDisconnectable = "Server không kết nỗi được";
        public const string OTP_VerifyFailed = "Mã OTP không đúng";
        public const string OTP_VerifySuccess = "OTP Success";

        //Form
        public const string Form_Invalid = "Yêu cầu nhập đầy đủ thông tin";

    }
}