﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Verarbeitung {
    using EingabeAusgabe;
    using Fehlerbehandung;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Polynom {
        private double[] Vorfaktoren {
            get;
            set;
        }

        public Polynom(double[] vorfaktoren) {
            Vorfaktoren = vorfaktoren;
        }

        public virtual double Get(double x) {
            double wert = 0;
            for (int i = 0; i < Vorfaktoren.Count(); i++)
                wert += Vorfaktoren[i] * Math.Pow(x, i);
            return wert;
        }

        public virtual Polynom GetIntegration() {
            double[] vorfaktoren = new double[Vorfaktoren.Count()+1];
            vorfaktoren[0] = 0;
            for (int i = 0; i < Vorfaktoren.Count(); i++)
                vorfaktoren[i + 1] = Vorfaktoren[i] * 1.0 / i;
            return new Polynom(vorfaktoren);
        }

    }
}

