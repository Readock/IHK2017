//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace Verarbeitung {
    using EingabeAusgabe;
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Klasse welche ein Polynom Repraesentiert
    /// </summary>
    public class Polynom {
        /// <summary>
        /// Vorfaktoren des Polynoms
        /// (z. B. {0,1,5} bedeutet x+5x^2)
        /// </summary>
        public double[] Vorfaktoren {
            get;
            set;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="vorfaktoren">Vorfaktoren des Polynoms</param>
        public Polynom(double[] vorfaktoren) {
            Vorfaktoren = vorfaktoren;
        }

        /// <summary>
        /// Ermittelt den Funktionswert des Polynoms zum Zeitpunkt X
        /// </summary>
        /// <param name="x">Zeitpunkt</param>
        /// <returns>Funktionswert</returns>
        public virtual double Get(double x) {
            double wert = 0;
            // Iteriere über alle Aenderungs Daten solange bis Zeitpunkt > x
            for (int i = 0; i < Vorfaktoren.Count(); i++)
                wert += Vorfaktoren[i] * Math.Pow(x, i);
            return wert;
        }

        /// <summary>
        /// Ermittelt die Integration des Polynoms
        /// </summary>
        /// <returns>Integration</returns>
        public virtual Polynom GetIntegration() {
            // Erzeuge neues Feld für Vorfaktoren
            double[] vorfaktoren = new double[Vorfaktoren.Count()+1];
            // Erstes Element auf 0 setzen
            vorfaktoren[0] = 0;
            // Iteriere über Vorfaktoren mit Laufvariable i
            for (int i = 0; i < Vorfaktoren.Count(); i++)
                // Füge dem Feld an der Stelle i den Vorfaktor an der Stelle i-1 hinzu
                // Multipliziere Stelle des Feldes mit 1/i
                vorfaktoren[i + 1] = Vorfaktoren[i] * (1 / (i+1.0));
            // Erzeuge neues Polynom aus dem Feld und gebe es zurück
            return new Polynom(vorfaktoren);
        }
    }
}

