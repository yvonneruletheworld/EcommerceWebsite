using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Interfaces
{
    public interface IProductServices 
    {
        List<Product> GetListProduct();

        bool? KiemTra(string value);
    }
}
