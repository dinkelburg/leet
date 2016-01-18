using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Exceptions
{
    /// <summary>
    /// Een Exception die optreed wanneer de gebruiker verkeerde invoer geeft.
    /// Heeft geen eigen properties, maar wordt gebruikt om niet 'Exception' te hoeven vangen.
    /// Gebruiksvriendelijke melding staat in Message.
    /// </summary>
    public class FunctionalException : Exception
    {
        public FunctionalException(string melding) : base(melding) { }
    }
}
