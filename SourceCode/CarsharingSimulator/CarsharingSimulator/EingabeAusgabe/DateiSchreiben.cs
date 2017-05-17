//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace EingabeAusgabe {
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Verarbeitung;

    /// <summary>
    /// Klasse welche das schreiben von AusgabeDaten in eine Datei ermoeglicht
    /// </summary>
    public class DateiSchreiben : ISchreiber {
        /// <summary>
        /// Der Pfad zur Datei welche erzeugt werden soll
        /// </summary>
        private string DateiPfad {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="path">Dateipfad</param>
        public DateiSchreiben(string path) {
            DateiPfad = path;
        }

        /// <summary>
        /// Schreibt die Daten in eine Datei
        /// </summary>
        /// <param name="data">Daten</param>
        public virtual void Schreiben(AusgabeDaten data) {
            // Textausgabe Generieren
            string text = data.GeneriereText();
            // Text in Datei Schreiben
            File.WriteAllText(DateiPfad, text);
        }

    }
}

