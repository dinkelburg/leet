using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Exceptions
{
    /// <summary>
    /// Een Exception die optreed wanneer er zaken fout gaan die niet hadden mogen gebeuren, fout van programmeur ipv gebruiker.
    /// Heeft geen eigen properties, maar wordt gebruikt om niet 'Exception' te hoeven vangen.
    /// Melding staat in Message.
    /// </summary>
    public class TechnicalException : Exception
    {
        public TechnicalException(string melding) : base(melding) { }
    }
}
