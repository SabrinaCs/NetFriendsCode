// ---------------------------------------------------------------
// Definizione della classe SplitChecker
// ---------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;



namespace ListeNumeri
{
	///<summary>
	/// Implementazione del controllo di consistenza di una serie di numeri non consecutivi
	/// A che serve?
	/// Serve in una funzione che splitta in modo arbitrario il contenuto di un PDF,
	/// per verificare se l'utente ha incluso tutte le pagine ed evidenziare quelle che mancano
	/// In modo che se c'è un errore sia corretto e se invece è voluto l'utente possa andare
	/// avanti con i dati da lui inserito
	///</summary>
	public class SplitChecker
	{

		
		public void CheckList(List<int> allPages, int pagesTotal)
		{
			List<TwoInts> inPages = new List<TwoInts>();
			List<TwoInts> outPages = new List<TwoInts>();
			TwoInts currentInPages = null;
			TwoInts currentOutPages = null;

			foreach (int page in allPages.OrderBy(x => x))
			{
				//Primo giro
				if (currentInPages == null)
				{
					currentInPages = new TwoInts(page, page);
					inPages.Add(currentInPages);
					//Primo giro
					if (currentOutPages == null)
					{
						if (page > 1)
						{
							currentOutPages = new TwoInts(1, page - 1);
							outPages.Add(currentOutPages);
						}
					}
				}
				//Giri successivi
				else
				{
					if (page - currentInPages.End > 1)
					{
						currentOutPages = new TwoInts(currentInPages.End + 1, page - 1);
						outPages.Add(currentOutPages);
						currentInPages = new TwoInts(page, page);
						inPages.Add(currentInPages);
					}
					else
					{
						currentInPages.End = page;
					}
				}


			}
			//Se in coda al file mancano pagine splittate aggiungo
			//Una coppia con le pagine mancanti.
			int pageMax = allPages.Max();
			if (pageMax < pagesTotal)
			{
				currentOutPages = new TwoInts(pageMax + 1, pagesTotal);
				outPages.Add(currentOutPages);
			}
			Console.WriteLine($"Total pages are: {pagesTotal}");
			Console.WriteLine("Pages included in the split operation");
			string sep = "";
			foreach (TwoInts segment in inPages)
			{
				Console.Write(sep);
				Console.Write(segment.ToString());
				sep = ", ";
			}
			Console.WriteLine();

			Console.WriteLine("Pages NOT included in the split operation");
			sep = "";
			foreach (TwoInts segment in outPages)
			{
				Console.Write(sep);
				Console.Write(segment.ToString());
				sep = ", ";
			}
			Console.WriteLine();


		}


	}

	internal class TwoInts
	{

		public TwoInts(int start, int end)
		{
			Start = start;
			End = end;
		}

		///<summary> 
		/// Primo degli interi
		///</summary>   
		public int Start
		{
			get;
			set;
		}


		///<summary> 
		/// ultimo degli interi
		///</summary>   
		public int End
		{
			get;
			set;
		}


		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			if (End > Start)
			{
				sb.AppendFormat("{0}-{1}", Start, End);
			}
			else
			{
				sb.Append(Start);
			}
			return (sb.ToString());
		}

	}
}