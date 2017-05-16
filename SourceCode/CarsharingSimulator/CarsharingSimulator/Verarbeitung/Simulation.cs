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
            BeraechneBedarf();
        }

        /// <summary>
        /// Initialisiert Alle Bedarfsfunktionen
        /// </summary>
        private void BeraechneBedarf() {
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
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
        public virtual int[,] BeraechneEndzustand() {
            var endzustand = new int[EingabeDaten.M, EingabeDaten.M];
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
                    endzustand[x, y] = Bedarf[x, y].Get(24);
                }
            }
            return endzustand;
        }
        /// <summary>
        /// Ermittelt den Maximalen Bedarf fuer alle Positionen
        /// </summary>
        /// <returns>Maximaler Bedarf</returns>
        public virtual int[,] BeraechneMaxBedarf() {
            var max = new int[EingabeDaten.M, EingabeDaten.M];
            for (int y = 0; y < EingabeDaten.M; y++) {
                for (int x = 0; x < EingabeDaten.M; x++) {
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
            // TODO add Endzustand und MaxBedarf
            var daten = new AusgabeDaten(EingabeDaten);
            var liste = new List<Aenderung>();
            foreach (var item in Bedarf)
                liste.AddRange(item.Daten);
            liste.Sort((a, b) => {
                int compare = a.Zeitpunkt.CompareTo(b.Zeitpunkt);
                if (compare == 0 && a.IsNachfrage && !b.IsNachfrage)
                    compare = -1; // Nachfrage hat vorrang wenn gleiche zeit
                if (compare == 0 && b.IsNachfrage && !a.IsNachfrage)
                    compare = 1;
                return compare;
            });
            daten.Simulationsverlauf = liste.Select(a => a.ToString()).ToList();
            daten.Endzustand = BeraechneEndzustand();
            daten.Maximalbedarf = BeraechneMaxBedarf();
            return daten;
        }
    }
}

