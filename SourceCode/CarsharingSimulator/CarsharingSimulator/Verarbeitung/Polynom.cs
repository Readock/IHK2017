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
            throw new System.NotImplementedException();
        }

        public virtual Polynom GetIntegration() {
            throw new System.NotImplementedException();
        }

    }
}

