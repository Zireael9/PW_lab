using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Threading;


/// <summary>
/// zadanie PO9/5
/// wywo�anie:
/// zadanie z = new zadanie();
/// z.zadaniaWszystkie();
/// </summary>
namespace zadania
{

    [Serializable]
    public class Student
    {
        public String Imi�;
        public String Nazwisko;
        public int Album;
        public int RokUro;
        public int Sem;
        public float �rednia;
    }


    [Serializable]
    public class Wyk�adowca
    { 
        public String Imi�;
        public String Nazwisko;
        public int Sem;
    }



    [Serializable]
    public class Listy
    {
        public List<Student> ls = new List<Student>();
        public List<Wyk�adowca> lw = new List<Wyk�adowca>();
    }



    public class zadanie
    {
        Listy listy;

        public zadanie()
        {
            readFile();
        }

        public void readFile()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            listy = new Listy();
            XmlSerializer xs = new XmlSerializer(typeof(Listy));
            FileStream data = File.OpenRead("SW.xml");
            listy = (Listy)xs.Deserialize(data);
        }

        public void zadaniaWszystkie()
        {
            Console.WriteLine("Podpunkt A: ");
            zadA();
            Console.WriteLine();
            Console.WriteLine("Podpunkt B: ");
            zadB();
            Console.WriteLine();
            Console.WriteLine("Podpunkt C: ");
            zadC();
            Console.WriteLine();
            Console.WriteLine("Podpunkt D: ");
            zadD();
            Console.WriteLine();
            Console.WriteLine("Podpunkt E: ");
            zadE();
            Console.WriteLine();
            Console.WriteLine("Podpunkt F: ");
            zadF();
            Console.WriteLine();
            Console.WriteLine("Podpunkt G: ");
            zadG();
            Console.WriteLine();
            Console.WriteLine("Podpunkt H: ");
            zadH();
            Console.WriteLine();
            Console.WriteLine("Podpunkt I: ");
            zadI();
            Console.WriteLine();
            Console.WriteLine("Podpunkt J: ");
            zadJ();
            Console.WriteLine();
        }


        /// <summary>
        /// a) pe�ne dane wszystkich student�w uporz�dkowane rosn�co wg. semestr�w,
        /// </summary>
        public void zadA()
        {
            var a = from st in listy.ls orderby st.Sem select st;
            foreach (var s in a)
            {
                Console.WriteLine("Imie:" + s.Imi� + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.�rednia);
            }
        }


        /// <summary>
        /// b) imiona i nazwiska student�w I stopnia studi�w (sem. I do VII) uporz�dkowane malej�co wg. numer�w album�w
        /// </summary>
        public void zadB()
        {
            var b = from st in listy.ls where st.Sem >= 1 && st.Sem <= 7 orderby st.Album descending select st;
            foreach (var s in b)
            {
                Console.WriteLine("Imie:" + s.Imi� + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.�rednia);
            }
        }

        /// <summary>
        /// c) odpowied� na pytanie, czy w zbiorze student�w (m�czyzn) s� starsi ni� 26 lat,
        /// </summary>
        public void zadC()
        {
            var c = from st in listy.ls where st.RokUro + 26 <= 2018 && !st.Imi�.EndsWith("a") select st;
            if (c != null) Console.WriteLine("S� m�czy�ni starsi ni� 26 lat");
            else Console.WriteLine("Brak m�czyzn starszych ni� 26 lat");
        }

        /// <summary>
        /// d) pe�ne dane studentek z VII semestru,
        /// </summary>
        public void zadD()
        {
            var d = from st in listy.ls where st.Sem == 7 && st.Imi�.EndsWith("a") select st;
            foreach (var s in d)
            {
                Console.WriteLine("Imie:" + s.Imi� + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.�rednia);
            }

        }


        /// <summary>
        /// e) przeci�tn� �redni� student�w II stopnia studi�w (sem. VIII - X)
        /// </summary>
        public void zadE()
        {
            var a = (from st in listy.ls where st.Sem >= 7 select st.�rednia).Average();
            Console.WriteLine("�rednia:" + a);

        }

        /// <summary>
        /// f) nazwiska i imiona student�w, z kt�rymi prowadzi zaj�cia wskazany wyk�adowca,
        /// </summary>
        public void zadF()
        {
            var f = from st in listy.ls
                    join sw in listy.lw on st.Sem equals sw.Sem
                    select new
                    {
                        StudentImie = st.Imi�,
                        NazwiskoStudent = st.Nazwisko,
                        WykladowcaImie = sw.Imi�,
                        WykladowcaNazwisko = sw.Nazwisko
                    };
            Console.WriteLine("Zapytanie F : ");
            foreach (var s in f)
            {
                Console.WriteLine("{0}", s);
            }
        }

        /// <summary>
        /// g) imi� i nazwisko studenta o najwy�szej �redniej i studenta o najni�szej �redniej,
        /// </summary>
        public void zadG()
        {
            var g = from st in listy.ls where st.�rednia == listy.ls.Max(x => x.�rednia) || st.�rednia == listy.ls.Min(x => x.�rednia) select st;
            foreach (var s in g)
            {
                Console.WriteLine(s.Imi� + " " + s.Nazwisko + " " + s.�rednia);
            }
        }

        /// <summary>
        /// h) imiona, nazwiska i nr albumu student�w podgrupowane wg. numer�w semestr�w.
        /// </summary>
        public void zadH()
        {
            var h = from st in listy.ls orderby st.Sem ascending group st by st.Sem into g select new { Semestr = g.Key, Studenci = g.ToList() };
            foreach (var s in h)
            {
                Console.WriteLine("Semestr : {0}", s.Semestr);
                foreach (var x in s.Studenci)
                {
                    Console.WriteLine("{0} {1}", x.Imi�, x.Nazwisko);
                }
            }
        }

        /// <summary>
        /// i) LINQ: zmieniaj� wszystkim studentom numery semestr�w na o 1 wi�ksze (poza studentami X semestru - dla nich wpisa� nr semestru -1),
        /// </summary>
        public void zadI()
        {
            (from st in listy.ls where st.Sem <= 9 select st).ToList().ForEach(st => st.Sem += 1);
            (from st in listy.ls where st.Sem == 10 select st).ToList().ForEach(st => st.Sem = -1);
            var zapytanieI = from st in listy.ls select st;
            Console.WriteLine("Zapytanie I : ");
            foreach (var s in zapytanieI)
            {
                Console.WriteLine("Imie: " + s.Imi� + ", Nazwiako: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro: " + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.�rednia);
            }
        }

        /// <summary>
        /// j)LINQ: zmniejszaj� studentom o podanym imieniu numer semestru o 1,
        /// </summary>
        public void zadJ()
        {
            String imieX = "Adam";
            (from st in listy.ls where st.Imi� == imieX select st).ToList().ForEach(st => st.Sem -= 1);
            var j = from st in listy.ls select st;
            foreach (var s in j)
            {
                Console.WriteLine("Imie: " + s.Imi� + ", Nazwiako: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro: " + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.�rednia);
            }

        }
    }
}
