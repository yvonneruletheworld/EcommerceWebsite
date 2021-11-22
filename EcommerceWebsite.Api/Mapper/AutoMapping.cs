using AutoMapper;
using EcommerceWebsite.Data.Entities;
using EcommerceWebsite.Utilities.Input;
using EcommerceWebsite.Utilities.Output.Main;
using EcommerceWebsite.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SanPham, SanPhamOutput>();
           
            CreateMap<SanPhamOutput, SanPhamVM>();
        }
    }
}
