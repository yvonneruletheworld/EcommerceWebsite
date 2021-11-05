using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.System
{
    public class HUIServices : IHUIServices
    {
        public async IAsyncEnumerable<HUI> ReadFromTextToList(string fileName)
        {
            using StreamReader reader = File.OpenText(fileName);
            var stt = 0;
            while(!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                HUI hui = new HUI()
                {
                    Id = "hui_" + stt++,
                    Utility = double.Parse(line.Trim().Split(":")[1]),
                    Itemsets = line.Trim()
                                   .Split(":")[0].Split(",")
                };
                
                yield return hui;
            }
        }
    }
}
