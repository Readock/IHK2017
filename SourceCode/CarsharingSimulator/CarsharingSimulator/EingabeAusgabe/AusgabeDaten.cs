﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace EingabeAusgabe {
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Verarbeitung;

    /// <summary>
    /// Klasse welche Informationen zur berrechneten Lösung der Simulation haelt
    /// </summary>
    public class AusgabeDaten {
        /// <summary>
        /// Eingabedaten auf die sich die Ergebnisse beziehen
        /// </summary>
        public virtual EingabeDaten InputData {
            get;
            set;
        }

        /// <summary>
        /// Verlauf der Simulation im Format "{Aktion} in Q_{position} zu t={zeitpunkt}"
        /// </summary>
        public virtual List<string> Simulationsverlauf {
            get;
            set;
        }

        /// <summary>
        /// Der berrechnete Endzustand der Simulation
        /// </summary>
        public virtual int[,] Endzustand {
            get;
            set;
        }

        /// <summary>
        /// Der maximale Bedarf der waerend der simulation auftritt
        /// </summary>
        public virtual int[,] Maximalbedarf {
            get;
            set;
        }


        public AusgabeDaten(EingabeDaten inputData) {
            InputData = inputData;
            Simulationsverlauf = new List<string>();
            Endzustand = new int[InputData.M, InputData.M];
            Maximalbedarf = new int[InputData.M, InputData.M];
        }

        /// <summary>
        /// Generiert einen Text der z. B. in eine Ausgabe Datei geschreiben werden kann
        /// </summary>
        /// <returns>Text als string</returns>
        public virtual string GeneriereText() {
            // Kommentarzeile
            var text = InputData.Kopfzeile + Environment.NewLine;
            // Historie
            foreach (var item in Simulationsverlauf)
                text += item + Environment.NewLine;
            // Endzustand
            text += "# Endzustand des Tages:" + Environment.NewLine;
            for (int i = 0; i < Endzustand.GetLength(1); i++) {
                for (int j = 0; j < Endzustand.GetLength(0); j++) 
                    text += Endzustand[i, j] + " ";                
                text += Environment.NewLine;
            }
            // Maximalbedarf
            text += "# Maximaler Bedarf:" + Environment.NewLine;
            for (int i = 0; i < Maximalbedarf.GetLength(1); i++) {
                for (int j = 0; j < Maximalbedarf.GetLength(0); j++) 
                    text += Maximalbedarf[i, j] + " ";                
                text += Environment.NewLine;
            }
            return text;
        }
    }
}

