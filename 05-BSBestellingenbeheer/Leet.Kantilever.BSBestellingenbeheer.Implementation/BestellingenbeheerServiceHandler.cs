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
using Minor.case3.Leet.V1.FunctionalError;

namespace Leet.Kantilever.BSBestellingenbeheer.Implementation
{
    public class BestellingenbeheerServiceHandler : IBestellingenbeheerService
    {
        private IDatamapper<DAL.Entities.Bestelling> _mapper;

        public BestellingenbeheerServiceHandler()
        {
            _mapper = new BestellingDataMapper();
        }

        public BestellingenbeheerServiceHandler(IDatamapper<DAL.Entities.Bestelling> mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Create new bestelling
        /// </summary>
        /// <param name="requestMesssage"></param>
        public void CreateBestelling(CreateBestellingRequestMessage requestMesssage)
        {
            _mapper.Insert(DTOToEntity.BestellingToEntity(requestMesssage.Bestelling));
        }

        /// <summary>
        /// Update bestelling information
        /// </summary>
        /// <param name="requestMessage"></param>
        public void UpdateBestelling(UpdateBestellingRequestMessage requestMessage)
        {
            var entity = DTOToEntity.BestellingToEntity(requestMessage.Bestelling);
            _mapper.Update(entity);
        }

        /// <summary>
        /// Find all bestellingen
        /// </summary>
        /// <returns></returns>
        public GetAllBestellingenResponseMessage FindAllBestelling()
        {
            var bestellingen = EntityToDTO.BestellingCollectionToDto(_mapper.FindAll());
            return new GetAllBestellingenResponseMessage
            {
                BestellingCollection = bestellingen
            };
        }

        /// <summary>
        /// Find bestelling using bestelnummer
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public GetBestellingByBestelnummerResponseMessage FindBestelling(GetBestellingByBestelnummerRequestMessage requestMessage)
        {
            var bestelling = _mapper.Find(b => b.Bestelnummer == requestMessage.Bestelnummer).SingleOrDefault();

            var errorList = new FunctionalErrorList();
            if (bestelling == null)
            {
                errorList.Add(new FunctionalErrorDetail
                {
                    Message = "Er is geen factuur gevonden met het bestelnummer " + requestMessage.Bestelnummer,
                });
            }

            if (errorList.Any())
            {
                throw new FaultException<FunctionalErrorList>(errorList);
            }

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
            var errorList = new FunctionalErrorList();
            try
            {
                var volgendeBestelling = _mapper.FindNext();
                return new GetVolgendeOpenBestellingResponseMessage
                {
                    Bestelling = EntityToDTO.BestellingToDto(volgendeBestelling)
                };
            }
            catch (ArgumentException ex)
            {
                errorList.Add(new FunctionalErrorDetail
                {
                    Message = ex.Message,
                });

                throw new FaultException<FunctionalErrorList>(errorList);
            }
        }

        /// <summary>
        /// Based on a klant's klantnummer, returns all his bestellingen.
        /// </summary>
        /// <param name="requestMessage">The message containing the klantnummer.</param>
        /// <returns></returns>
        public GetAllBestellingenByKlantResponseMessage GetAllBestellingenByKlant(GetAllBestellingenByKlantRequestMessage requestMessage)
        {
            var errorList = new FunctionalErrorList();

            try
            {
                var bestellingEntities = _mapper.Find(b => b.Klantnummer == requestMessage.KlantNummer);

                var bestellingDtoCollection = EntityToDTO.BestellingCollectionToDto(bestellingEntities);

                var response = new GetAllBestellingenByKlantResponseMessage
                {
                    BestellingCollection = bestellingDtoCollection
                };

                return response;
            }
            catch (ArgumentException ex)
            {
                errorList.Add(new FunctionalErrorDetail
                {
                    Message = ex.Message,
                });

                throw new FaultException<FunctionalErrorList>(errorList);
            }
        }
    }
}
