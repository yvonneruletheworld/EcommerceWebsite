using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Services.Interfaces.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.Main
{
    public class BoPhanServices : IBoPhanServices
    {
        private readonly EcomWebDbContext dbContext;

        public BoPhanServices(EcomWebDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BoPhan>> LayDanhSachBoPhan()
        {
            return await dbContext.BoPhans.ToListAsync();
        }
    }
}
