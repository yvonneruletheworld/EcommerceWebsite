using EcommerceWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Utilities.Output.System
{
    public class HUI
    {
        public string Id { get; set; }
        public double Utility { get; set; }
        public string[] Itemsets { get; set; }
        
        //public List<ChiTietHoaDon>   SanPhams { get; set; }
    }

    public static class HUIConfiguration
    {
        public static List<HUI> ListHUI { get; set; }
    }
}
