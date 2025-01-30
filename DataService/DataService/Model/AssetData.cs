using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    public class AssetData : AssetSummary
    {
       public string Id { get; set; }
       public List<string> Machines { get; set; }
    }
}
