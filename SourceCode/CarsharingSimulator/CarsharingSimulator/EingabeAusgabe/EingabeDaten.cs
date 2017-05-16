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
    /// Klasse welche daten Enthaelt die fuer eine Simulation benoetigt werden
    /// </summary>
    public class EingabeDaten {
        /// <summary>
        /// Dimension der Simulierten Quadrate (insgesamt M*M Quadrate)
        /// </summary>
        public virtual int M {
            get;
            set;
        }

        /// <summary>
        /// Angebotsverteilungen fuer jedes Quadrat
        /// </summary>
        public virtual Polynom[,] AngebotVerteilung {
            get;
            set;
        }

        /// <summary>
        /// NachfrageVerteilungen fuer jedes Quadrat
        /// </summary>
        public virtual Polynom[,] NachfrageVerteilung {
            get;
            set;
        }

        /// <summary>
        /// Kopfzeile
        /// </summary>
        public virtual string Kopfzeile {
            get;
            set;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="m"></param>
        public EingabeDaten(int m) {
            M = m;
            AngebotVerteilung = new Polynom[m, m];
            NachfrageVerteilung = new Polynom[m, m];
            Kopfzeile = "";
        }

    }
}

