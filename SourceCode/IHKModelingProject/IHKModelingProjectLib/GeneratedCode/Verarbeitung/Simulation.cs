﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Verarbeitung
{
	using EingabeAusgabe;
	using Fehlerbehandung;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Simulation
	{
		public virtual EingabeDaten EingabeDaten
		{
			get;
			private set;
		}

		public virtual Bedarf Bedarf
		{
			get;
			private set;
		}

		public virtual double Genauigkeit
		{
			get;
			private set;
		}

		public Simulation(EingabeDaten daten, double genauigkeit)
		{
		}

		private void BeraechneBedarf()
		{
			throw new System.NotImplementedException();
		}

		public virtual int BeraechneEndzustand()
		{
			throw new System.NotImplementedException();
		}

		public virtual int BeraechneMaxBedarf()
		{
			throw new System.NotImplementedException();
		}

		public virtual AusgabeDaten GeneriereAusgabe()
		{
			throw new System.NotImplementedException();
		}

	}
}
