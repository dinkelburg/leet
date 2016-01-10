using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using Leet.Kantilever.PcSWinkelen.V1.Messages;
using Leet.Kantilever.PcSWinkelen.DAL;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.Agent;
using BsCatalogus = Kantilever.BsCatalogusbeheer.Product.V1;
using AutoMapper;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    public class WinkelenServiceHandler : IWinkelenService
    {
        private IDataMapper<Winkelmand, long> _productMapper;
        private IAgentBSCatalogusBeheer _agentBSCatalogusBeheer;

        public WinkelenServiceHandler()
        {
            _productMapper = new WinkelmandDataMapper();
            _agentBSCatalogusBeheer = new AgentBSCatalogusBeheer();
        }

        public WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {
            throw new NotImplementedException();
        }

        public WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {

            var agentProduct = _agentBSCatalogusBeheer.FindProductById(toevoegenWinkelmandReqMessage.BestelProduct.ProductID);
            Mapper.CreateMap<BsCatalogus.Product, Product>()
            .ForMember(dest => dest.CatalogusProductID, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            var product = Mapper.Map<Product>(agentProduct);
            product.Aantal = toevoegenWinkelmandReqMessage.BestelProduct.Aantal;
            _productMapper.AddProductToWinkelmand(product, toevoegenWinkelmandReqMessage.BestelProduct.ClientID);

            return null;
        }
    }
}