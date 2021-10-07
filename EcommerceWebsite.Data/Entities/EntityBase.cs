using System;

namespace EcommerceWebsite.Data.Entities
{
    public class EntityBase
    {
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string LastModificationUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleterTime { get; set; }
        public string DeleteUserId { get; set; }

    }
}