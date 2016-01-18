using Leet.Kantilever.BSKlantbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.BSKlantbeheer.V1.Messages;
using Leet.Kantilever.BSKlantbeheer.DAL.Mappers;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using System.Data;
using Leet.Kantilever.BSKlantbeheer.DAL.Exceptions;

namespace Leet.Kantilever.BSKlantbeheer.Implementation
{
    /// <summary>
    /// See the interface for details.
    /// </summary>
    public class KlantbeheerServiceHandler : IKlantbeheerService
    {
        public GetAllKlantenResponseMessage GetAllKlanten()
        {
            var mapper = new KlantDataMapper();
            KlantenCollection result = new KlantenCollection();
            try
            {
                result.AddRange(mapper.GetAllKlanten());
                return new GetAllKlantenResponseMessage { Klanten = result };
            }
            catch (DataException ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public GetKlantByKlantnummerResponseMessage GetKlant(GetKlantByKlantnummerRequestMessage requestMessage)
        {
            var mapper = new KlantDataMapper();
            try
            {
                Klant klant = mapper.FindKlant(requestMessage.Klantnummer);
                return new GetKlantByKlantnummerResponseMessage { Klant = klant };
            }
            catch (InvalidOperationException)
            {
                // Klantnummer was niet bekend
                throw new FaultException($"Dit klantnummer({requestMessage.Klantnummer}) was niet bekend.");
            }
            catch (ArgumentNullException)
            {
                throw new FaultException("Klantnummer was niet opgegeven.");
            }
        }

        public void RegistreerKlant(InsertKlantGegevensRequestMessage requestMessage)
        {
            var mapper = new KlantDataMapper();
            try
            {
                mapper.InsertKlant(requestMessage.Klant);
            }
            catch(FunctionalException ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
