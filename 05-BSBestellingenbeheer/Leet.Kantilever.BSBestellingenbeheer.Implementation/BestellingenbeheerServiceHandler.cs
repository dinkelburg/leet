using Leet.Kantilever.BSBestellingenbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using Leet.Kantilever.BSBestellingenbeheer.V1.Messages;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;
using Leet.Kantilever.BSBestellingenbeheer.DAL.mappers;
using Leet.Kantilever.BSBestellingenbeheer.DAL;
using Leet.Kantilever.BSBestellingenbeheer.DAL.converters;
using System.ServiceModel;

namespace Leet.Kantilever.BSBestellingenbeheer.Implementation
{
    public class BestellingenbeheerServiceHandler : IBestellingenbeheerService
    {
        /// <summary>
        /// Create new bestelling
        /// </summary>
        /// <param name="requestMesssage"></param>
        public void CreateBestelling(CreateBestellingRequestMessage requestMesssage)
        {
            var mapper = new BestellingDataMapper();
            mapper.AddBestelling(DTOToEntity.BestellingToEntity(requestMesssage.Bestelling));
        }

        /// <summary>
        /// Update bestelling information
        /// </summary>
        /// <param name="requestMessage"></param>
        public void UpdateBestelling(UpdateBestellingRequestMessage requestMessage)
        {
            var entity = DTOToEntity.BestellingToEntity(requestMessage.Bestelling);
            var mapper = new BestellingDataMapper();
            try
            {
                entity.ID = mapper.Find(b => b.Bestelnummer == entity.Bestelnummer).SingleOrDefault().ID;
            } catch
            {
                throw new FaultException("Cannot update non existing entity");
            }
            mapper.Update(entity);
        }

        /// <summary>
        /// Find all bestellingen
        /// </summary>
        /// <returns></returns>
        public GetAllBestellingenResponseMessage FindAllBestelling()
        {
            var bestellingen = new BestellingCollection();

            return new GetAllBestellingenResponseMessage { BestellingCollection = bestellingen};
        }

        /// <summary>
        /// Find bestelling using bestelnummer
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public GetBestellingByBestelnummerResponseMessage FindBestelling(GetBestellingByBestelnummerRequestMessage requestMessage)
        {

            var mapper = new BestellingDataMapper();
            var bestelling = mapper.Find(b => b.Bestelnummer == requestMessage.Bestelnummer).Single();

            return new GetBestellingByBestelnummerResponseMessage
            {
                Bestelling = EntityToDTO.BestellingToDto(bestelling)
            };
        }

        /// <summary>
        /// Get the next Bestelling which isn't packed yet
        /// </summary>
        /// <returns>The first Bestelling that is ready to be picked</returns>
        public GetVolgendeOpenBestellingResponseMessage GetVolgendeOpenBestelling()
        {
            BestellingDataMapper mapper = new BestellingDataMapper();
            var volgendeBestelling =
                    mapper.FindVolgendeOpenBestelling();
            return new GetVolgendeOpenBestellingResponseMessage
            {
                Bestelling = EntityToDTO.BestellingToDto(volgendeBestelling)
            };
        }
    }
}
