using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Opracowa� program prowadz�cy spis samochod�w (max. 125 samochod�w). Ka�dy samoch�d opisany jest za pomoc� obiektu klasy zawieraj�cej mark�, rok_produkcji i cen� samochodu (sk�adowe prywatne). 
 * Dost�p do tych sk�adowych prywatnych umo�liwiaj� w�a�ciwo�ci. Program realizuje  nast�puj�ce polecenia:
R : wczytanie liczby samochod�w i tablicy obiekt�w opisuj�cych samochody z pliku dyskowego Baza.txt,
N :  wczytanie danych opisuj�cych samoch�d z konsoli i wprowadzenie ich  do kolejnej pozycji tablicy obiekt�w,
W : wy�wietlanie informacji o wszystkich samochodach,
Z : zapis liczby samochod�w i tabeli obiekt�w do pliku dyskowego Baza.txt,
K : zako�czenie programu.
Do obs�ugi opcji zastosowa� kolekcj� Dictionary<char, FunOp>.*/



/*WYWOLANIE:
    zadanie z = new zadanie();
    z.showOptions();
 */

namespace Lab_kolejne
{

    class zadanie
    {
        bool exit = false;
        Dictionary<String, int> dictSwitch;
        string fileName = "Baza.txt";
        int max = 125;
        List<Samochod> samochody;
        public zadanie()
        {
            samochody = new List<Samochod>();
            dictSwitch = new Dictionary<string, int>();
            dictSwitch.Add("r", 1);
            dictSwitch.Add("n", 2);
            dictSwitch.Add("w", 3);
            dictSwitch.Add("z", 4);
            dictSwitch.Add("k", 5);
        }


        public void showOptions()
        {
            while (!exit)
            {

                Console.WriteLine("Podaj odpowiedni� liter�:");
                Console.WriteLine("R: wczytanie liczby samochod�w i tablicy obiekt�w opisuj�cych samochody z pliku dyskowego Baza.txt,");
                Console.WriteLine("N: wczytanie danych opisuj�cych samoch�d z konsoli i wprowadzenie ich do kolejnej pozycji tablicy obiekt�w,");
                Console.WriteLine("W: wy�wietlanie informacji o wszystkich samochodach,");
                Console.WriteLine("Z: zapis liczby samochod�w i tabeli obiekt�w do pliku dyskowego Baza.txt,");
                Console.WriteLine("K: zako�czenie programu.");
                string opt = Console.ReadLine().ToLower();
                switch (dictSwitch[opt])
                {
                    case 1:
                        {
                            r();
                            break;
                        }
                    case 2:
                        {
                            n();
                            break;
                        }
                    case 3:
                        {
                            w();
                            break;
                        }
                    case 4:
                        {
                            z();
                            break;
                        }
                    case 5:
                        {
                            k();
                            break;
                        }

                }
            }
        }

        public void r()
        {
            try
            {
                FileInfo file = new FileInfo(fileName);
                StreamReader sr = file.OpenText();
                string line = sr.ReadLine();
                int counter = 0;
                while(line!=null && counter < max)
                {
                    String [] words = line.Split();
                    samochody.Add(new Samochod(words[0], words[1], words[2]));
                    counter++;
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("B��d przy odczycie pliku.");
            }
        }

        public void n()
        {
            if (samochody.Count < max)
            {
                Console.WriteLine("Podaj marke:");
                string m = Console.ReadLine();
                Console.WriteLine("Podaj rok produkcji:");
                string r = Console.ReadLine();
                Console.WriteLine("Podaj cene:");
                string c = Console.ReadLine();
                samochody.Add(new Samochod(m, r, c));
            }
            else Console.WriteLine("Za duzo samochodow!");
        }

        public void w()
        {
            foreach (var s in samochody)
            {
                Console.WriteLine(s.Marka+" "+s.Rok_produkcji+" "+s.Cena);
            }
        }

        public void z()
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var s in samochody)
            {
                sw.Write(s.Marka+" "+s.Rok_produkcji+" "+s.Cena+"\n");
            }
            sw.Close();

        }

        public void k()
        {
            exit = true;
        }



    }


    class Samochod
    {
        private string marka;
        private string rok_produkcji;
        private string cena;


        public Samochod(string m, string r, string c)
        {
            Marka = m;
            Rok_produkcji = r;
            cena = c;
        }

        public string Marka { get => marka; set => marka = value; }
        public string Rok_produkcji { get => rok_produkcji; set => rok_produkcji = value; }
        public string Cena { get => cena; set => cena = value; }

        


    }
}
