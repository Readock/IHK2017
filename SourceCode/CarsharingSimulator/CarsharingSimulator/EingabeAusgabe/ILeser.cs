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
    /// Interface fuer das Lesen von Daten
    /// </summary>
    public interface ILeser {
        /// <summary>
        /// Liest Daten ein
        /// </summary>
        /// <returns>Daten</returns>
        EingabeDaten Lesen();
    }
}

