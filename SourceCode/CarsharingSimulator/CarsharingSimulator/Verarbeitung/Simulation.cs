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
    /// Klasse welche die Simulation ausfuert
    /// </summary>
    public class Simulation {
        /// <summary>
        /// Eingabe Daten
        /// </summary>
        public virtual EingabeDaten EingabeDaten {
            get;
            private set;
        }
        /// <summary>
        /// Die Bedarfsfunktionen fuer alle Positionen
        /// </summary>
        public virtual Bedarf[,] Bedarf {
            get;
            private set;
        }
        /// <summary>
        /// Die Genauigkeit mit der simuliert wird
        /// </summary>
        public virtual double Genauigkeit {
            get;
            private set;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="daten">Daten</param>
        /// <param name="genauigkeit">Genauigkeit</param>
        public Simulation(EingabeDaten daten, double genauigkeit) {
            Bedarf = new Bedarf[daten.M, daten.M];
            EingabeDaten = daten;
            Genauigkeit = genauigkeit;
            BerechneBedarf();
        }

        /// <summary>
        /// Initialisiert Alle Bedarfsfunktionen
        /// </summary>
        private void BerechneBedarf() {
            // Iteriere ueber Quadrate
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
                    // Erzeuge Bedarf und speichere diesen ab
                    Bedarf[x, y] = new Bedarf(
                        EingabeDaten.AngebotVerteilung[x, y],
                        EingabeDaten.NachfrageVerteilung[x, y],
                        x, y, Genauigkeit);
                }
            }
        }

        /// <summary>
        /// Ermittelt den Endzustand der Simulation
        /// </summary>
        /// <returns>Endzustand</returns>
        public virtual int[,] BerechneEndzustand() {
            var endzustand = new int[EingabeDaten.M, EingabeDaten.M];
            // Ermittle für jedes Quadrat den Bedarf von 24
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
                    // Speichere alle Werte in einem Feld
                    endzustand[x, y] = Bedarf[x, y].Get(24);
                }
            }
            return endzustand;
        }

        /// <summary>
        /// Ermittelt den Maximalen Bedarf fuer alle Positionen
        /// </summary>
        /// <returns>Maximaler Bedarf</returns>
        public virtual int[,] BerechneMaxBedarf() {
            var max = new int[EingabeDaten.M, EingabeDaten.M];
            // Ermittle für jedes Quadrat den Maximalen Bedarf
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
                    // Speichere alle Werte in einem Feld
                    max[x, y] = Bedarf[x, y].BeraechneMaxBedarf();
                }
            }
            return max;
        }

        /// <summary>
        /// Generiert AusgabeDaten der Simulation
        /// </summary>
        /// <returns>AusgabeDaten</returns>
        public virtual AusgabeDaten GeneriereAusgabe() {
            var liste = new List<Aenderung>();
            // Iteriere ueber jeden Bedarf
            foreach (var item in Bedarf)
                // Füge Daten des Bedarfs in Liste ein
                liste.AddRange(item.Daten);
            // Sortiere Liste der Daten nach Zeitpunkt 
            // (mit beachtung von Nachfrage zuerst wenn zeit identisch)
            liste.Sort((a, b) => {
                int compare = a.Zeitpunkt.CompareTo(b.Zeitpunkt);
                if (compare == 0 && a.IsNachfrage && !b.IsNachfrage)
                    compare = 1; // Nachfrage hat vorrang wenn gleiche zeit
                if (compare == 0 && b.IsNachfrage && !a.IsNachfrage)
                    compare = -1;
                return compare;
            });
            // Erzeuge AusgabeDaten
            var daten = new AusgabeDaten(EingabeDaten);
            // Erzeuge neue Liste mit Strings aus der Liste mit Daten
            // und setze diese in Ausgabe Daten ein
            daten.Simulationsverlauf = liste.Select(a => a.ToString()).ToList();
            // Berechne den Endzustand und füge ihn den AusgabeDaten hinzu
            daten.Endzustand = BerechneEndzustand();
            // Berechne den Maximalbedarf und füge ihn den AusgabeDaten hinzu
            daten.Maximalbedarf = BerechneMaxBedarf();
            // Gebe die Ausgabedaten zurueck
            return daten;
        }
    }
}

