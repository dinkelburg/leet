using Leet.Kantilever.PcSWinkelen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Leet.Kantilever.PcSWinkelen.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WinkelenServiceHandler : IWinkelenService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

    }
}