/*WYWOLANIE
	List<Drukarka> listaDrukarek = new List<Drukarka>();
	listaDrukarek.Add(new Drukarka(false, 100));
	listaDrukarek.Add(new Drukarka(true, 100));
	listaDrukarek.Add(new Drukarka(true, 150));
	listaDrukarek.Add(new Drukarka(false, 500));
	listaDrukarek.Sort();
	foreach (Drukarka print in listaDrukarek)
	{
		System.Console.WriteLine(" Kolor: " + print.Kolor + " Predkosc: " +
		print.predkoscDRUKU);
	}

*/





namespace Lab3_Drukarka
{
	class Drukarka : IComparable<Drukarka>
	{
		private Boolean kolor;
		private double predkoscDruku;
		
		public Boolean Kolor
		{
			get { return kolor; }
		}
		
		public double predkoscDRUKU
		{
			get { return predkoscDruku; }
			set { if (value >=1 && value <=100) predkoscDruku = value;}
		}
		
		public Drukarka (Boolean kolor, double predkoscDruku)
		{
			this.kolor = kolor;
			this.predkoscDruku = predkoscDruku;
		}
		
		public int CompareTo(Drukarka that)
		{
			if (this.kolor != that.kolor) 
			{
				return this.kolor.CompareTo(that.kolor);
			}
			else 
			{
				return this.predkoscDruku.CompareTo(that.predkoscDruku);
			}
		}
	}
}