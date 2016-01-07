using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Leet.Kantilever.PcSWinkelen.V1.Messages;
using Leet.Kantilever.PcSWinkelen.DAL;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using Leet.Kantilever.PcSWinkelen.Agent;
using AutoMapper;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WinkelenServiceHandler : IWinkelenService
    {
        private IDataMapper<Product, long> _productMapper;
        private IAgentBSCatalogusBeheer _agentBSCatalogusBeheer;

        public WinkelenServiceHandler()
        {
            _productMapper = new ProductDataMapper();
            _agentBSCatalogusBeheer = new AgentBSCatalogusBeheer();
        }

        public WinkelmandResponseMessage GetWinkelmandje(VraagWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {
            throw new NotImplementedException();
        }

        public WinkelmandResponseMessage VoegProductToe(ToevoegenWinkelmandRequestMessage toevoegenWinkelmandReqMessage)
        {

            //Product product = _agentBSCatalogusBeheer.FindProductById(toevoegenWinkelmandReqMessage.BestelProduct.ProductID);
            //Mapper.CreateMap<Product, Leet.Kantilever.PcSWinkelen.DAL.Entities.Product>();
            return null;
        }
    }
}