using EcommerceWebsite.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceWebsite.Data.Identity
{
    public class KhachHangVM : IdentityUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string LastModificationUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleterTime { get; set; }
        public string DeleteUserId { get; set; }
        public string HoTen { get; set; }
        public string LoginString { get; set; }
        public bool GioiTinh { get; set; }

        public Status Status { get; set; }
    }
}
