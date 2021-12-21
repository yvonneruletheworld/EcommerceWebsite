using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Utilities.Output.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebsite.Services.Services.System
{
    public class HUIServices : IHUIServices
    {
        public Task<Dictionary<string, List<string>>> ModifyListOutput(List<HUI> inputList)
        {
            // sort asc
            inputList = inputList.OrderByDescending(hui => hui.Utility).ToList();

            //get item
            var listItem = new List<string>();
            foreach (var hui in inputList)
            {
                listItem = ReadListHUI(hui.Itemsets, listItem).ToList();
            }
            return null;
        }

        private IEnumerable<string> ReadListHUI(string[] itemSet, List<string> listItem)
        {
            foreach (var ip in itemSet)
            {
                if (!listItem.Contains(ip))
                {
                    yield return ip;
                }
            }
        }
        public async IAsyncEnumerable<HUI> ReadFromTextToList(string fileName)
        {
            using StreamReader reader = File.OpenText(fileName);
            var stt = 0;
            while(!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                HUI hui = new HUI()
                {
                    Id = "hui-" + stt++,
                    Utility = double.Parse(line.Trim().Split(":")[1]),
                    Itemsets = line.Trim()
                                   .Split(":")[0].Split(",")
                                   .Select(it => it.Trim()).ToArray()
                };
                
                yield return hui;
            }
        }

        //private string[] FormatArray(string[] vs)
        //{
        //    //vs = null;
        //    //foreach (var item in vs)
        //    //{
        //    //    var newItem = item.Trim();
        //    //    vs
        //    //}
        //    vs.
        //    return vs;
        //}
    }
}
