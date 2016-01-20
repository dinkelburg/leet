using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using Leet.Kantilever.PcSWinkelen.V1.Messages;
using Leet.Kantilever.PcSWinkelen.DAL;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.Agent;
using BsCatalogus = Kantilever.BsCatalogusbeheer.Product.V1;
using Schema = Leet.Kantilever.PcSWinkelen.V1.Schema;
using AutoMapper;
using System.Collections.Generic;
using Minor.case3.Leet.V1.FunctionalError;
using System.Linq;
using System.ServiceModel;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    public class WinkelenServiceHandler : IWinkelenService
    {
        private IDatamapper<Winkelmand> _winkelmandMapper;
        private IAgentBSCatalogusBeheer _agentBSCatalogusBeheer;

        /// <summary>
        /// Constructor to instantiate WinkelenServiceHandler with a WinkelmandDataMapper and AgentBSCatalogusBeheer
        /// </summary>
        public WinkelenServiceHandler()
        {
            _winkelmandMapper = new WinkelmandDatamapper();
            _agentBSCatalogusBeheer = new AgentBSCatalogusBeheer();
        }

        /// <summary>
        /// Constructor to instantiate WinkelenServiceHandler and to inject a WinkelmandDataMapper and AgentBSCatalogusBeheer mock
        /// </summary>
        /// <param name="productMapper">IDataMapper<Winkelmand> mock</param>
        /// <param name="agentBSCatalogusBeheer">IAgentBSCatalogusBeheer mock</param>
        public WinkelenServiceHandler(IDatamapper<Winkelmand> productMapper, IAgentBSCatalogusBeheer agentBSCatalogusBeheer)
        {
            _winkelmandMapper = productMapper;
            _agentBSCatalogusBeheer = agentBSCatalogusBeheer;
        }

        /// <summary>
        /// Implements the contract of GetWinkelmandje
        /// It gets the Winkelmand based on the ClientID in the VraagWinkelmandRequestMessage
        /// </summary>
        /// <param name="vraagWinkelmandRequestMessage">Message with the ClientID</param>
        /// <returns>WinkelmandResponseMessage with the Winkelmand that matches the ClientID</returns>
        public WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage vraagWinkelmandRequestMessage)
        {
            var winkelmand = _winkelmandMapper.FindWinkelmandByClientID(vraagWinkelmandRequestMessage.ClientID);
            var errorList = new FunctionalErrorList();
            //logger.Error("Test");
            if (winkelmand == null)
            {
                errorList.Add(new FunctionalErrorDetail
                {
                    Message = "Er is geen winkelmandje beschikbaar met het clientID " + vraagWinkelmandRequestMessage.ClientID,
                });
            }

            if(errorList.Any())
            {
                throw new FaultException<FunctionalErrorList>(errorList);
            }

            return MapWinkelmand(winkelmand);
        }

        /// <summary>
        /// Maps a Winkelmand to a WinkelmandResponseMessage
        /// </summary>
        /// <param name="dalWinkelmand">Winkelmand from the DAL</param>
        /// <returns>Mapped WinkelmandResponseMessage</returns>
        private static WinkelmandResponseMessage MapWinkelmand(Winkelmand dalWinkelmand)
        {
            Mapper.CreateMap<Product, schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CatalogusProductID));

            Schema.Winkelmand winkelmand = new Schema.Winkelmand();

            foreach (var product in dalWinkelmand.Products)
            {
                winkelmand.Add(new Schema.WinkelmandRegel
                {
                    Aantal = product.Aantal,
                    Product = Mapper.Map<schemaswwwkantilevernl.bscatalogusbeheer.product.v1.Product>(product),
                });
            }

            return new WinkelmandResponseMessage
            {
                Winkelmand = winkelmand,
            };
        }

        /// <summary>
        /// Implements the contract of VoegProductToe
        /// It gets the product that matches the ProductID from the BSCatalogusBeheer service and add it to the winkelmand.
        /// And returns the entire Winkelmand
        /// </summary>
        /// <param name="toevoegenWinkelmandRequestMessage">Message with ClientID, ProductID and Amount</param>
        /// <returns>The entire Winkelmand</returns>
        public WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandRequestMessage)
        {
            var agentProduct = _agentBSCatalogusBeheer.FindProductById(toevoegenWinkelmandRequestMessage.BestelProduct.ProductID);
            Mapper.CreateMap<BsCatalogus.Product, Product>()
            .ForMember(dest => dest.CatalogusProductID, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            var product = Mapper.Map<Product>(agentProduct);
            product.Aantal = toevoegenWinkelmandRequestMessage.BestelProduct.Aantal;
            _winkelmandMapper.AddProductToWinkelmand(product, toevoegenWinkelmandRequestMessage.BestelProduct.ClientID);

            var winkelmand = _winkelmandMapper.FindWinkelmandByClientID(toevoegenWinkelmandRequestMessage.BestelProduct.ClientID);

            return MapWinkelmand(winkelmand);
        }

        /// <summary>
        /// Implements the contract of BestelWinkelmand
        /// It removes the Winkelmand based on the ClientID in the VraagWinkelmandRequestMessage
        /// </summary>
        /// <param name="vraagWinkelmandReqMessage"></param>
        public void RemoveWinkelmand(VraagWinkelmandRequestMessage vraagWinkelmandRequestMessage)
        {
            _winkelmandMapper.RemoveWinkelmandByClientID(vraagWinkelmandRequestMessage.ClientID);
        }
    }
}