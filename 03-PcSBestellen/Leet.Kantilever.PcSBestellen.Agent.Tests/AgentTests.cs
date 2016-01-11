using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kantilever.BsCatalogusbeheer.V1;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class AgentTests
    {
        [TestMethod]
        public void TestGetOneProductById()
        {
            AgentBSCatalogusBeheer agent = new AgentBSCatalogusBeheer();
            try
            {
                var result = agent.GetProductsById(new int[] { 123 });
            }
            catch (Exception e)
            {
                Assert.Fail("Ophalen van producten faalde met de volgende parameters:", e);
            }            
        }
    }
}
