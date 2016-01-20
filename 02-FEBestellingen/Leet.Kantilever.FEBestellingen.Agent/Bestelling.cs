using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.V1.Schema
{
    public partial class Bestelling
    {
        /// <summary>
        /// Set current status of the bestelling
        /// Add status betaald with the or operator to have multiple statuses
        /// </summary>
        /// <param name="status">Status to set</param>
        public void SetStatus(Bestellingsstatus status)
        {
            Bestellingsstatus currentStatus = (Bestellingsstatus)this.Status;

            if (status == Bestellingsstatus.Betaald)
            {
                this.Status = (int)(currentStatus | status);
            }
            else if ((currentStatus & Bestellingsstatus.Betaald) > 0)
            {
                this.Status = (int)(status | Bestellingsstatus.Betaald);
            }
            else
            {
                this.Status = (int)status;
            }

        }
    }
}
