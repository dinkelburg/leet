﻿using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using Leet.Kantilever.PcSWinkelen.V1.Messages;
using Leet.Kantilever.PcSWinkelen.DAL;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.Agent;
using BsCatalogus = Kantilever.BsCatalogusbeheer.Product.V1;
using Schema = Leet.Kantilever.PcSWinkelen.V1.Schema;
using AutoMapper;
using System.Collections.Generic;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    public class WinkelenServiceHandler : IWinkelenService
    {
        private IDataMapper<Winkelmand> _productMapper;
        private IAgentBSCatalogusBeheer _agentBSCatalogusBeheer;

        /// <summary>
        /// Constructor to instantiate WinkelenServiceHandler with a WinkelmandDataMapper and AgentBSCatalogusBeheer
        /// </summary>
        public WinkelenServiceHandler()
        {
            _productMapper = new WinkelmandDataMapper();
            _agentBSCatalogusBeheer = new AgentBSCatalogusBeheer();
        }

        /// <summary>
        /// Constructor to instantiate WinkelenServiceHandler and to inject a WinkelmandDataMapper and AgentBSCatalogusBeheer mock
        /// </summary>
        /// <param name="productMapper">IDataMapper<Winkelmand> mock</param>
        /// <param name="agentBSCatalogusBeheer">IAgentBSCatalogusBeheer mock</param>
        public WinkelenServiceHandler(IDataMapper<Winkelmand> productMapper, IAgentBSCatalogusBeheer agentBSCatalogusBeheer)
        {
            _productMapper = productMapper;
            _agentBSCatalogusBeheer = agentBSCatalogusBeheer;
        }

        /// <summary>
        /// Implements the contract of GetWinkelmandje
        /// It gets the Winkelmand based on the ClientID in the VraagWinkelmandRequestMessage
        /// </summary>
        /// <param name="vraagWinkelmandReqMessage">Message with the ClientID</param>
        /// <returns>WinkelmandResponseMessage with the Winkelmand that matches the ClientID</returns>
        public WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage vraagWinkelmandReqMessage)
        {
            var winkelmand = _productMapper.FindWinkelmandByClientId(vraagWinkelmandReqMessage.ClientID);

            if(winkelmand == null)
            {
                throw new KeyNotFoundException("Er is geen winkelmandje beschikbaar met het clientID " + vraagWinkelmandReqMessage.ClientID);
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
        /// <param name="toevoegenWinkelmandReqMessage">Message with ClientID, ProductID and Amount</param>
        /// <returns>The entire Winkelmand</returns>
        public WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {
            var agentProduct = _agentBSCatalogusBeheer.FindProductById(toevoegenWinkelmandReqMessage.BestelProduct.ProductID);
            Mapper.CreateMap<BsCatalogus.Product, Product>()
            .ForMember(dest => dest.CatalogusProductID, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            var product = Mapper.Map<Product>(agentProduct);
            product.Aantal = toevoegenWinkelmandReqMessage.BestelProduct.Aantal;
            _productMapper.AddProductToWinkelmand(product, toevoegenWinkelmandReqMessage.BestelProduct.ClientID);

            var winkelmand = _productMapper.FindWinkelmandByClientId(toevoegenWinkelmandReqMessage.BestelProduct.ClientID);
            return MapWinkelmand(winkelmand);
        }
    }
}