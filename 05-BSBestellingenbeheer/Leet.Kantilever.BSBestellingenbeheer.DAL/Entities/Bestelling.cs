using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Entities
{
    class Bestelling
    {
        public int ID { get; set; }
        public long Bestelnummer { get; set; }
        public virtual Bestellingsregel Bestellingsregel { get; set; }
        public long KlantID { get; set; }
        public DateTime Datum { get; set; }
        public bool Ingepakt { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
