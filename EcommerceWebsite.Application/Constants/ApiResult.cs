using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Constants
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }
        [JsonProperty("token")]
        public T ResultObj { get; set; }
    }
}