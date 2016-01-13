﻿using System.Collections.Generic;
using Leet.Kantilever.BSBestellingenbeheer.V1.Schema;

namespace Leet.Kantilever.PcSBestellen.Agent
{
    public interface IBSBestellingenbeheerAgent
    {
        IEnumerable<Bestelling> GetAllBestellingen();
        Bestelling GetBestellingByID(long id);

        void CreateBestelling(Bestelling bestelling);
    }
}