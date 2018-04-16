namespace zadania
{
	class Program
	{
		static void Main(string[] args)
		{
			Text T1 = new Text();
			Text T2 = new Text("Polewka");
			T1.Napis = "Kapusniak";
			T2.Napis = "OK";
			Console.WriteLine("Hello World!");
			Console.WriteLine("Napis T1 : {0} ",T1.Napis);
			Console.WriteLine("Napis T2 : {0} ", T2.Napis);
		}
	}


	public class Text
	{
		private String napis;
		public String Napis
			{
			get { return this.napis; }
			set { if (value.Length > 3) this.napis = value; }

		}
		
		public Text(String param) {
			this.napis = param;
		}

	}
	
}