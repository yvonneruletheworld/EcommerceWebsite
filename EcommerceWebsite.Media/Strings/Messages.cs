using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Media.Strings
{
    public class Messages
    {
        public string ErrorLength (string field, int max, int min)
        {
            return field + " từ " + min + " kí tự đến " + max + " kí tự";
        }
    }
}
