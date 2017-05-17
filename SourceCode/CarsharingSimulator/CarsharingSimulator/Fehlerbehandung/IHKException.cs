//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace Fehlerbehandung {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Exception welche eine Fehlermeldung auf der Konsole ausgibt und das Programm dann beendet
    /// </summary>
    public class IHKException : System.Exception {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="message">Fehlernachricht</param>
        public IHKException(string message) {
            Console.WriteLine($"ERROR: {message}");
            Environment.Exit(1);
        }
    }
}

