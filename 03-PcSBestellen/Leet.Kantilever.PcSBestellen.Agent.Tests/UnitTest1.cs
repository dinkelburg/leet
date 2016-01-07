using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leet.Kantilever.PcSBestellen.Agent.Tests
{
    [TestClass]
    public class UnitTest1
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
