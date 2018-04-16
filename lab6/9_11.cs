using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_kolejne
{
   
    class ZadanieDrugie
    {
        string dir = @"C:\Users\mw121\Documents\Visual Studio 2017\Projects\Lab_kolejne\Lab_kolejne\Dane";
        string[] fileEntries;
        ZadaniePierwsze zp; //tylko funkcje mierz¹ce czas
        public ZadanieDrugie()
        {
            zp = new ZadaniePierwsze();
            fileEntries = Directory.GetFiles(dir, "*.txt");
        }



        public void countE(string path)
        {
            string readText = File.ReadAllText(path);
            string[] tab = readText.Split();
            int sum = 0;
            foreach (String x in fileEntries)
            {

                FileInfo f = new FileInfo(x);
                StreamReader sr = f.OpenText();
                while (!sr.EndOfStream)
                {
                    String[] zawartosc = sr.ReadLine().Split(' ');
                    var e = from i in zawartosc where i.Contains('e') select i;
                    sum += e.Count();

                }

            }

            Console.WriteLine("Plik: "+path+", liczba wystapien e: "+sum.ToString());
            
        }


        public void count()
        {
            Console.WriteLine("Normalne liczenie");
            zp.startWatch();
            foreach(string path in fileEntries)
            {
                countE(path);
            }
            zp.stopWatch();
            long ms = zp.getElapsedTime();
            Console.WriteLine("Czas: " + ms.ToString() + "ms");
        }

        public void countPar()
        {
            Console.WriteLine("Parallel");
            zp.startWatch();
            Parallel.ForEach(fileEntries, i =>
                {
                    countE(i);
                });
            zp.stopWatch();
            long ms = zp.getElapsedTime();
            Console.WriteLine("Czas: " + ms.ToString() + "ms");
        }

    }


}
