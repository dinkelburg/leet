using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL.Entities
{
    public class Winkelmand
    {
        public long ID { get; set; }
        public string ClientID { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
