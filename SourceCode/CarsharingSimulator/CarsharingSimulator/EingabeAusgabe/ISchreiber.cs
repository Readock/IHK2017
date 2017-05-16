//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace EingabeAusgabe {
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Verarbeitung;

    /// <summary>
    /// Interface zum Schreiben von Daten
    /// </summary>
    public interface ISchreiber {
        /// <summary>
        /// Schreibt Daten
        /// </summary>
        /// <param name="data">Daten</param>
        void Schreiben(AusgabeDaten data);
    }
}

