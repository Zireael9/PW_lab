using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Threading;


/// <summary>
/// zadanie PO9/5
/// wywo³anie:
/// zadanie z = new zadanie();
/// z.zadaniaWszystkie();
/// </summary>
namespace zadania
{

    [Serializable]
    public class Student
    {
        public String Imiê;
        public String Nazwisko;
        public int Album;
        public int RokUro;
        public int Sem;
        public float Œrednia;
    }


    [Serializable]
    public class Wyk³adowca
    { 
        public String Imiê;
        public String Nazwisko;
        public int Sem;
    }



    [Serializable]
    public class Listy
    {
        public List<Student> ls = new List<Student>();
        public List<Wyk³adowca> lw = new List<Wyk³adowca>();
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
        /// a) pe³ne dane wszystkich studentów uporz¹dkowane rosn¹co wg. semestrów,
        /// </summary>
        public void zadA()
        {
            var a = from st in listy.ls orderby st.Sem select st;
            foreach (var s in a)
            {
                Console.WriteLine("Imie:" + s.Imiê + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.Œrednia);
            }
        }


        /// <summary>
        /// b) imiona i nazwiska studentów I stopnia studiów (sem. I do VII) uporz¹dkowane malej¹co wg. numerów albumów
        /// </summary>
        public void zadB()
        {
            var b = from st in listy.ls where st.Sem >= 1 && st.Sem <= 7 orderby st.Album descending select st;
            foreach (var s in b)
            {
                Console.WriteLine("Imie:" + s.Imiê + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.Œrednia);
            }
        }

        /// <summary>
        /// c) odpowiedŸ na pytanie, czy w zbiorze studentów (mê¿czyzn) s¹ starsi ni¿ 26 lat,
        /// </summary>
        public void zadC()
        {
            var c = from st in listy.ls where st.RokUro + 26 <= 2018 && !st.Imiê.EndsWith("a") select st;
            if (c != null) Console.WriteLine("S¹ mê¿czyŸni starsi ni¿ 26 lat");
            else Console.WriteLine("Brak mê¿czyzn starszych ni¿ 26 lat");
        }

        /// <summary>
        /// d) pe³ne dane studentek z VII semestru,
        /// </summary>
        public void zadD()
        {
            var d = from st in listy.ls where st.Sem == 7 && st.Imiê.EndsWith("a") select st;
            foreach (var s in d)
            {
                Console.WriteLine("Imie:" + s.Imiê + ", Nazwisko: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro:" + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.Œrednia);
            }

        }


        /// <summary>
        /// e) przeciêtn¹ œredni¹ studentów II stopnia studiów (sem. VIII - X)
        /// </summary>
        public void zadE()
        {
            var a = (from st in listy.ls where st.Sem >= 7 select st.Œrednia).Average();
            Console.WriteLine("Œrednia:" + a);

        }

        /// <summary>
        /// f) nazwiska i imiona studentów, z którymi prowadzi zajêcia wskazany wyk³adowca,
        /// </summary>
        public void zadF()
        {
            var f = from st in listy.ls
                    join sw in listy.lw on st.Sem equals sw.Sem
                    select new
                    {
                        StudentImie = st.Imiê,
                        NazwiskoStudent = st.Nazwisko,
                        WykladowcaImie = sw.Imiê,
                        WykladowcaNazwisko = sw.Nazwisko
                    };
            Console.WriteLine("Zapytanie F : ");
            foreach (var s in f)
            {
                Console.WriteLine("{0}", s);
            }
        }

        /// <summary>
        /// g) imiê i nazwisko studenta o najwy¿szej œredniej i studenta o najni¿szej œredniej,
        /// </summary>
        public void zadG()
        {
            var g = from st in listy.ls where st.Œrednia == listy.ls.Max(x => x.Œrednia) || st.Œrednia == listy.ls.Min(x => x.Œrednia) select st;
            foreach (var s in g)
            {
                Console.WriteLine(s.Imiê + " " + s.Nazwisko + " " + s.Œrednia);
            }
        }

        /// <summary>
        /// h) imiona, nazwiska i nr albumu studentów podgrupowane wg. numerów semestrów.
        /// </summary>
        public void zadH()
        {
            var h = from st in listy.ls orderby st.Sem ascending group st by st.Sem into g select new { Semestr = g.Key, Studenci = g.ToList() };
            foreach (var s in h)
            {
                Console.WriteLine("Semestr : {0}", s.Semestr);
                foreach (var x in s.Studenci)
                {
                    Console.WriteLine("{0} {1}", x.Imiê, x.Nazwisko);
                }
            }
        }

        /// <summary>
        /// i) LINQ: zmieniaj¹ wszystkim studentom numery semestrów na o 1 wiêksze (poza studentami X semestru - dla nich wpisaæ nr semestru -1),
        /// </summary>
        public void zadI()
        {
            (from st in listy.ls where st.Sem <= 9 select st).ToList().ForEach(st => st.Sem += 1);
            (from st in listy.ls where st.Sem == 10 select st).ToList().ForEach(st => st.Sem = -1);
            var zapytanieI = from st in listy.ls select st;
            Console.WriteLine("Zapytanie I : ");
            foreach (var s in zapytanieI)
            {
                Console.WriteLine("Imie: " + s.Imiê + ", Nazwiako: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro: " + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.Œrednia);
            }
        }

        /// <summary>
        /// j)LINQ: zmniejszaj¹ studentom o podanym imieniu numer semestru o 1,
        /// </summary>
        public void zadJ()
        {
            String imieX = "Adam";
            (from st in listy.ls where st.Imiê == imieX select st).ToList().ForEach(st => st.Sem -= 1);
            var j = from st in listy.ls select st;
            foreach (var s in j)
            {
                Console.WriteLine("Imie: " + s.Imiê + ", Nazwiako: " + s.Nazwisko + ", Album: " + s.Album + ", RokUro: " + s.RokUro + ", Semestr:" + s.Sem + ", Srednia:" + s.Œrednia);
            }

        }
    }
}
