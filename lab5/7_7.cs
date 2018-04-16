using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Opracowaæ program prowadz¹cy spis samochodów (max. 125 samochodów). Ka¿dy samochód opisany jest za pomoc¹ obiektu klasy zawieraj¹cej markê, rok_produkcji i cenê samochodu (sk³adowe prywatne). 
 * Dostêp do tych sk³adowych prywatnych umo¿liwiaj¹ w³aœciwoœci. Program realizuje  nastêpuj¹ce polecenia:
R : wczytanie liczby samochodów i tablicy obiektów opisuj¹cych samochody z pliku dyskowego Baza.txt,
N :  wczytanie danych opisuj¹cych samochód z konsoli i wprowadzenie ich  do kolejnej pozycji tablicy obiektów,
W : wyœwietlanie informacji o wszystkich samochodach,
Z : zapis liczby samochodów i tabeli obiektów do pliku dyskowego Baza.txt,
K : zakoñczenie programu.
Do obs³ugi opcji zastosowaæ kolekcjê Dictionary<char, FunOp>.*/



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

                Console.WriteLine("Podaj odpowiedni¹ literê:");
                Console.WriteLine("R: wczytanie liczby samochodów i tablicy obiektów opisuj¹cych samochody z pliku dyskowego Baza.txt,");
                Console.WriteLine("N: wczytanie danych opisuj¹cych samochód z konsoli i wprowadzenie ich do kolejnej pozycji tablicy obiektów,");
                Console.WriteLine("W: wyœwietlanie informacji o wszystkich samochodach,");
                Console.WriteLine("Z: zapis liczby samochodów i tabeli obiektów do pliku dyskowego Baza.txt,");
                Console.WriteLine("K: zakoñczenie programu.");
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
                Console.WriteLine("B³¹d przy odczycie pliku.");
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
