using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Constants
{
    public static class EmailTemplate
    {
        public static class OTPLogin
        {
            public const string Title = "[TRIPLE V Store] Xác nhận tài khoản bằng OTP code ";
            public const string Content = @"<div style=""font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2"">
                                                <div style =""margin:50px auto; width:70%;padding:20px 0"">
                                                    <div style=""border-bottom:1px solid #eee"">
                                                        <a href = ""#"" style=""font-size:1.4em;color: #00466a;text-decoration:none;font-weight:600"">TRIPLE V Store</a>
                                                    </div>
                                                <p><strong>Xin chào {email},</strong></p>
                                                <p>Cảm ơn vì đã lựa chọn TRIPLE V Store. Sử dung mã OTP bên dưới để xác nhận yêu cầu mua hàng của bạn. Không chia sẻ mã OTP cho người khác</p>
                                                  <h2 style = ""background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;"" > {OTPCode} </h2>
                                                  <p style = ""font-size:0.9em;"" > Gửi từ,<br/>TRIPLE V Store</p>
                                                    <hr style = ""border:none;border-top:1px solid #eee"" />
                                                   <div style= ""float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300"">
                                                     <p> TRPLEV Inc</p>
                                                    <p>Ho Chi Minh</p>
                                                    <p>Vietnam</p>
                                                    </div>                                  
                                                </div>
                                            </div>";

        }

    }
}
