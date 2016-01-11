using minorcase3pcswinkelen.v1.schema;

namespace Leet.Kantilever.FEWebwinkel.Agent
{
    public interface IAgentPcSWinkelen
    {
        Winkelmand GetWinkelmand(string clientID);
        Winkelmand VoegProductToeAanWinkelmand(int productID, int aantal, string clientID);
    }
}