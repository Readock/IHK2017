//------------------------------------------------------------------------------
// Carsharing Simulator
//------------------------------------------------------------------------------
namespace Program {
    using EingabeAusgabe;
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Verarbeitung;

    /// <summary>
    /// Klasse welche die Main Methode beinhaltet
    /// </summary>
    public class Program {

        /// <summary>
        /// Main Methode die das Programm steuert
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            if(args.Count() == 0) // TODO: entferne dies spaeter
                args = new string[] { // nur zum Debuggen
                    @"..\..\..\..\..\Input\Sonderfall-GrosseZahlen2.in",
                    @"..\..\..\..\..\Output\Sonderfall-GrosseZahlen2.out",
                    "0.0001",
                };
            if (args.Count() != 2 || args.Count() != 3)
                throw new IHKException("Die Uebergebenen Parameteranzahl entspricht nicht den anforderungen [DateipfadEingabe] [DateipfadAusgabe] ([Genauigkeit])");
            if (!File.Exists(args[0]))
                throw new IHKException($"Es konnte keine Eingabedatei gefunden werden ({args[0]})");
            double genauigkeit = 0.0001;
            // ggf. Genauigkeit einlesen
            if (args.Count() == 3) {
                if (!Regex.IsMatch(args[2], @"[0-9]*\.?[0-9]*"))
                    throw new IHKException("Der 3. Uebergebene Paramteter ist keine positive Gleitkommazahl");
                genauigkeit = double.Parse(args[2], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
                if (genauigkeit > 1)
                    throw new IHKException("Die Genauigkeit sollte nicht ueber 1 sein (also z. B. 0.0001)");
            }
            // Daten einlesen
            ILeser leser = new DateiEinlesen(args[0]);
            var eingabeDaten = leser.Lesen();
            // Simulation berrechnen
            var simulation = new Simulation(eingabeDaten, genauigkeit);
            var ausgabeDaten = simulation.GeneriereAusgabe();
            // Ausgabe Schreiben
            ISchreiber schreiber = new DateiSchreiben(args[1]);
            schreiber.Schreiben(ausgabeDaten);
            Process.Start("notepad.exe", args[1]);
        }
    }
}

