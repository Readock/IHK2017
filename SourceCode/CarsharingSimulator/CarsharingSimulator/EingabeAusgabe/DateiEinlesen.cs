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
            // Pruefen ob Dateipfad existiert (ggf. Exception)
            if (!File.Exists(Dateipfad))
                throw new IHKException($"Die Datei \"{Dateipfad}\" Existiert nicht");
            // Alle Zeilen Einlesen
            var zeilen = File.ReadAllLines(Dateipfad).Where(a => !string.IsNullOrWhiteSpace(a)).ToList();
            // Erste Kommentarzeile Speichern
            string kommentarzeile = zeilen.FirstOrDefault(a => a.StartsWith("#"));
            // Kommentarzeilen entfernen
            zeilen = zeilen.Where(a => !a.StartsWith("#")).ToList();
            // Pruefen ob Datei leer ist
            if(zeilen.Count == 0)
                throw new IHKException("Die Eingabedatei ist leer");
            // m als Zahl einlesen (bei falschem Format Exception)
            // https://regex101.com/r/Ydgiso/1
            if (!Regex.IsMatch(zeilen.First(), @"^[0-9]*$"))
                throw new IHKException($"m=\"{zeilen.First()}\" hat das falsche Format (sollte eine positive Ganzzahl  groesser 0 sein)");
            int m = int.Parse(zeilen.First());
            if (m < 1)
                throw new IHKException($"m=\"{zeilen.First()}\" hat das falsche Format (sollte eine positive Ganzzahl  groesser 0 sein)");
            // Die Zeile mit m entfernen
            zeilen.RemoveAt(0);
            if (zeilen.Count != m*m*2)
                throw new IHKException("Es sind nicht genuegend Polynome angegeben worden "+
                    $"({2*m*m} erwartet und {zeilen.Count} gegeben)");
            var data = new EingabeDaten(m) {
                Kopfzeile = kommentarzeile,
            };
            // Iteriere ueber uebrige Zeilen
            for (int i = 0; i < m * m; i++) {
                // Polynome Erzeugen und speichern
                data.NachfrageVerteilung[i / m,i % m] = GetPolynom(zeilen[i]);
                data.AngebotVerteilung[i / m, i % m] = GetPolynom(zeilen[m * m + i]);
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
            // https://regex101.com/r/4cAArX/4
            if (!Regex.IsMatch(str, @"^([+-]?[0-9]+\.?[0-9]* +){4}[+-]?[0-9]+\.?[0-9]* *$"))
                throw new IHKException($"Die Angabe des Polynoms \"{str}\" liegt im falschen Format vor");
            // erzeugen eines neuen Polynoms
            var numbers = str.Replace("  "," ").Split(' ').
                Where(item => !string.IsNullOrWhiteSpace(item)).
                Select(number => double.Parse(number, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US")));
            return new Polynom(numbers.ToArray());
        }
    }
}

