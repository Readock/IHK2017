﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace EingabeAusgabe
{
	using Fehlerbehandung;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Verarbeitung;

	public class DateiSchreiben : ISchreiber
	{
		private string DateiPfad
		{
			get;
			set;
		}

		public DateiSchreiben(string path)
		{
		}

		public virtual void Schreiben(AusgabeDaten data)
		{
			throw new System.NotImplementedException();
		}

	}
}

