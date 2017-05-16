//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace EingabeAusgabe {
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Verarbeitung;

    /// <summary>
    /// Klasse welche das Einlesen von EingabeDaten aus einer Datei ermoeglicht
    /// </summary>
    public class DateiEinlesen : ILeser {
        /// <summary>
        /// Der Pfad zur Datei welche eingelesen werden soll
        /// </summary>
        private string Dateipfad {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="pfad">Dateipfad</param>
        public DateiEinlesen(string pfad) {
            Dateipfad = pfad;
        }

        /// <summary>
        /// Liest die EingabeDaten aus der angegebenen Datei ein
        /// </summary>
        /// <returns>Daten</returns>
        public virtual EingabeDaten Lesen() {
            // Prüfen ob Dateipfad existiert (ggf. Exception)
            if (!File.Exists(Dateipfad))
                throw new IHKException($"Die Datei \"{Dateipfad}\" Existiert nicht");
            // Alle Zeilen Einlesen
            var zeilen = File.ReadAllLines(Dateipfad).Where(a => !string.IsNullOrWhiteSpace(a)).ToList();
            // Erste Kommentarzeile Speichern
            string kommentarzeile = zeilen.FirstOrDefault(a => a.StartsWith("#"));
            // Kommentarzeilen entfernen
            zeilen = zeilen.Where(a => !a.StartsWith("#")).ToList();
            // m als Zahl einlesen
            if (!Regex.IsMatch(zeilen.First(), @"\d"))
                throw new IHKException("m hat das falsche Format (sollte eine Ganzezahl sein)");
            int m = int.Parse(zeilen.First());
            zeilen.RemoveAt(0);
            if (m < 1)
                throw new IHKException("m muss groesser oder gleich 1 sein");
            if(zeilen.Count != m*m*2)
                throw new IHKException($"Es sind nicht genuegend Polynome angegeben worden "+
                    "({2*m*m} erwartet und {zeilen.Count} gegeben)");
            var data = new EingabeDaten(m) {
                Kopfzeile = kommentarzeile,
            };
            // NachfrageVerteilungen einlesen
            for (int i = 0; i < m * m; i++) {
                data.NachfrageVerteilung[i / m,i % m] = GetPolynom(zeilen[i]);
            }
            // AngebotsVerteilungen einlesen
            for (int i = 0; i < m * m; i++) {
                data.AngebotVerteilung[i / m, i % m] = GetPolynom(zeilen[m*m+i]);
            }
            return data;
        }

        /// <summary>
        /// Erzeugt ein neues Polynom aus einem string
        /// </summary>
        /// <param name="str">Text</param>
        /// <returns>Funktion</returns>
        private Polynom GetPolynom(string str) {
            // Ueberprueft ob 5 Fließkommazahlen vorliegen
            // https://regex101.com/r/4cAArX/2
            if (!Regex.IsMatch(str, @"([+-]?[0-9]*\.?[0-9]* ){4}[+-]?[0-9]*\.?[0-9]*"))
                throw new IHKException("In der Eingabedatei liegt ein Formatierungsfehler vor");
            // erzeugen eines neuen Polynoms
            var numbers = str.Split(' ').Select(number => double.Parse(number, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US")));
            return new Polynom(numbers.ToArray());
        }

    }
}

