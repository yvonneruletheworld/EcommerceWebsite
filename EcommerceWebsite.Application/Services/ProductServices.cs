using EcommerceWebsite.Application.Interfaces;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly EcomWebDbContext context;

        public ProductServices(EcomWebDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetListProduct ()
        {
            return context.Products.ToList();
        }

        public bool? KiemTra(string value)
        {
            return value?.Contains("j");
        }
    }
}
