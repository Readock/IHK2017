﻿//------------------------------------------------------------------------------
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
    /// Bedarfsfunktion welche den Bedarf an Autos auf eine Position beschreibt
    /// </summary>
    public class Bedarf {
        /// <summary>
        /// Aenderungen also zu welchen Zeiten ein Auto zurueckgegeben oder nachgefragt wird
        /// </summary>
        public virtual List<Aenderung> Daten {
            get;
            private set;
        }

        /// <summary>
        /// Die Angebotsfunktion in form eines Polynoms
        /// </summary>
        public virtual Polynom Angebot {
            get;
            private set;
        }
        /// <summary>
        /// Die Nachfragesfunktion in form eines Polynoms
        /// </summary>
        public virtual Polynom Nachfrage {
            get;
            private set;
        }
        /// <summary>
        /// Die Genauigkeit mit der die Zeitpunkte der Aenderungen bestimmt werden sollen
        /// </summary>
        public virtual double Genauigkeit {
            get;
            private set;
        }
        /// <summary>
        /// X Position des Bedarfs
        /// </summary>
        public virtual int PosX {
            get;
            private set;
        }
        /// <summary>
        /// Y Position des Bedarfs
        /// </summary>
        public virtual int PosY {
            get;
            private set;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="angebot">Angebotsfunktion</param>
        /// <param name="nachfrage">Nachfragefunktion</param>
        /// <param name="posX">X Position</param>
        /// <param name="posY">Y Position</param>
        /// <param name="genauigkeit">Genauigkeit</param>
        public Bedarf(Polynom angebot, Polynom nachfrage, int posX, int posY, double genauigkeit) {
            Daten = new List<Aenderung>();
            PosX = posX;
            PosY = posY;
            Angebot = angebot;
            Nachfrage = nachfrage;
            Genauigkeit = genauigkeit;
            BeraechneDaten(angebot.GetIntegration(), false);
            BeraechneDaten(nachfrage.GetIntegration(), true);
        }

        /// <summary>
        /// Findet die Nullstelle (NST) vom angegebenen Polynom
        /// </summary>
        /// <param name="polynom">Funktion</param>
        /// <returns>Nullstellte</returns>
        private Nullable<double> FindeNST(Polynom polynom) {
            int anzahlIterationen = (int)Math.Ceiling(Math.Log(24 / Genauigkeit) / Math.Log(2));
            return Bisektion(0, 24, polynom, anzahlIterationen);
        }

        /// <summary>
        /// Ermittelt eine Nusllstelle (NST) mittels des Bisektionsverfahrens 
        /// </summary>
        /// <param name="a">Intervall beginn (es muss gelten a<b)</param>
        /// <param name="b">Intervall ende (es muss gelten a<b)</param>
        /// <param name="polynom">Die Funktion zu der eine NST gefunden werden soll</param>
        /// <param name="anzahlIterationen">Anzahl der Iterationen</param>
        /// <returns>Nullstelle</returns>
        private Nullable<double> Bisektion(double a, double b, Polynom polynom, int anzahlIterationen) {
            // mitte m ermitteln
            double m = a + (b - a)/2;
            // funktionswert von a, b und m ermitteln
            double fa = polynom.Get(a);
            double fb = polynom.Get(b);
            double fm = polynom.Get(m);
            bool vzw = (fa <= 0 && fb >= 0);
            // Vorzeichenwaechsel zwischen a und b ?
            if (!vzw)
                return null;
            // prüfen ob NST gefunden wenn ja zurückgeben
            if (fb == 0 || fa == 0 || fm == 0)
                return fa == 0 ? a : (fb == 0 ? b : m);
            if (anzahlIterationen == 0)
                return m;
            // neues Intervall Bestimmen und neue Rekrusion
            double newA = fm < 0 ? m : a;
            double newB = fm >= 0 ? m : b;
            return Bisektion(newA, newB, polynom, anzahlIterationen - 1);
        }

        /// <summary>
        /// Ermittelt den Maximalen Bedarf im verlaufe der Zeit
        /// </summary>
        /// <returns>Maximaler Bedarf</returns>
        public virtual int BeraechneMaxBedarf() {
            int max = 0; // da 0 startwert ist kann das max nie unter 0 fallen
            // sortiere Daten nach Zeitpunkt 
            // (mit beachtung von Nachfrage zuerst wenn zeit identisch)
            Daten.Sort((a, b) => {
                int compare = a.Zeitpunkt.CompareTo(b.Zeitpunkt);
                if (compare == 0 && a.IsNachfrage)
                    compare = -1; // Nachfrage hat vorrang wenn gleiche zeit
                if (compare == 0 && b.IsNachfrage)
                    compare = 1;
                return compare;
            });
            // Daten durchlaufen und groessten wert herausfiltern
            int currentValue = 0;
            foreach (var item in Daten) {
                currentValue += item.IsNachfrage ? 1 : -1;
                if (currentValue > max)
                    max = currentValue;
            }
            return max;
        }

        /// <summary>
        /// Beraechnet die Aenderungen der Bedarfsfunktion
        /// </summary>
        /// <param name="polynom">Funktion</param>
        /// <param name="isNachfrage">Art der Funktion</param>
        private void BeraechneDaten(Polynom polynom, bool isNachfrage) {
            for (int i = 1; true; i++) {
                double[] neueVorfaktoren = (double[]) polynom.Vorfaktoren.Clone();
                neueVorfaktoren[0] = neueVorfaktoren[0] - i;
                var verschobenesPolynom = new Polynom(neueVorfaktoren);
                var nst = FindeNST(verschobenesPolynom);
                if (!nst.HasValue)
                    return;
                Daten.Add(new Aenderung(polynom, isNachfrage, i, nst.Value, PosX, PosY));
            }
        }

        /// <summary>
        /// Ermittelt den Funktionswert der Bedarfsfunktion zum Zeitpunkt x
        /// </summary>
        /// <param name="x">Zeitpunkt</param>
        /// <returns>Funktionswert</returns>
        public virtual int Get(double x) {
            return Daten.Sum((item) => {
                if (item.Zeitpunkt > x)
                    return 0;
                return item.IsNachfrage ? 1 : -1;
            });
        }

    }
}

