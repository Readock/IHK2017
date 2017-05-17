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
    /// KLasse welche eine Aenderung in der Bedarfsfunktion darstellt
    /// </summary>
    public class Aenderung {
        /// <summary>
        /// Polynom zu welchem die Aenderung auftritt
        /// </summary>
        public virtual Polynom Polynom {
            get;
            set;
        }
        /// <summary>
        /// Gibt an ob es ich um eine Nachfrage oder Angebotsaenderung handelt
        /// </summary>
        public virtual bool IsNachfrage {
            get;
            set;
        }
        /// <summary>
        /// Funktionswert des Polynoms zum Zeitpunkt der Aenderung
        /// </summary>
        public virtual int Wert {
            get;
            set;
        }
        /// <summary>
        /// Zeitunkt zu dem die Aenderung auftritt
        /// </summary>
        public virtual double Zeitpunkt {
            get;
            set;
        }
        /// <summary>
        /// X Position der Aenderung
        /// </summary>
        public virtual int PosX {
            get;
            private set;
        }
        /// <summary>
        /// Y Position der Aenderung
        /// </summary>
        public virtual int PosY {
            get;
            private set;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="polynom">Funktion</param>
        /// <param name="isNachfrage">Typ der Funktion</param>
        /// <param name="wert">Funktionswert</param>
        /// <param name="zeitpunkt">Zeitpunkt</param>
        /// <param name="posX">X Position</param>
        /// <param name="posY">Y Position</param>
        public Aenderung(Polynom polynom, bool isNachfrage, int wert, double zeitpunkt, int posX, int posY) {
            PosX = posX;
            PosY = posY;
            Polynom = polynom;
            IsNachfrage = isNachfrage;
            Wert = wert;
            Zeitpunkt = zeitpunkt;
        }

        /// <summary>
        /// Erzeugt einen string fuer die Aenderung im Format "{Aktion} in Q_{position} zu t={zeitpunkt}"
        /// </summary>
        /// <returns>String</returns>
        public override string ToString() {
            var aktion = IsNachfrage ? "Nachfrage" : "Abstellung";
            return $"{aktion} in Q_{PosX+1}{PosY+1} zu t={Math.Round(Zeitpunkt,2)}";
        }
    }
}

