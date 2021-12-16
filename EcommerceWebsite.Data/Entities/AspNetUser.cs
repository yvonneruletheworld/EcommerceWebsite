using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Entities
{
    public class AspNetUser : EntityBase
    {
        public AspNetUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool PhoneNumber { get; set; }
    }
}
