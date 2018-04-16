/*
WYWOLANIE
Tekst2 t = new Tekst2();
            Tekst2 t1 = new Tekst2();
            Tekst2 t2 = new Tekst2();
            int l = t.len();
            int index;
            for (int i = 0; i<l; i++)
            {
                index = t1.con(t[i]);
                if (index >= 0)
                {
                    Console.WriteLine(index + " "+ t[i]);
                    t[i] = t2[index];
                }
            }
            t.wypisz();
*/

namespace PW1
{
    class Tekst2
    {
        public string[] tekst;
        public Tekst2()
        {
            Console.WriteLine("Podaj zdanie:");
            string t1 = Console.ReadLine();
            tekst = t1.Split();
        }

        public string this[int i]
        {
            get { return tekst[i]; }
            set { if (value is string) tekst[i] = value; }
        }

        public int len()
        {
            return tekst.Length;
        }

        public int con(string slowo)
        {
            int ret = -1;
            if (tekst.Contains(slowo))
            {
                int l = this.len();
                for (int i = 0; i<l; i++)
                {
                    if (tekst[i] == slowo)
                    {
                        ret = i;
                        break;
                    }
                }
                    
            }
            return ret;

        }

        public void wypisz()
        {
            int l = this.len();
            for (int i = 0; i < l; i++)
                Console.Write(tekst[i] + " ");
            Console.WriteLine();
        }

        
    }
}