using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW1
{
    public class Lab2
    {
        bool wczytana_macierz;
        bool exit;
        int n;
        int m;
        Double[,] arr;
        
        public Lab2()
        {
            wczytana_macierz = false;
            exit = false;
        }
        /*PN 5/6*/
        public bool zadaj_pytanie()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Podaj polecenie (n/N, k/K, q/Q lub w/W: ");
            String pol = Console.ReadLine().ToLower();
            char polecenie= pol[0];
            switch (polecenie)
            {
                case 'n':
                    wczytaj_macierz();
                    wczytana_macierz = true;
                    break;
                case 'k':
                    if (!wczytana_macierz)
                    {
                        Console.WriteLine("Najpierw musisz wykonaæ polecenie n/N!");
                    }
                    else wypisz_kolumny();
                    break;
                case 'w':
                    if (!wczytana_macierz)
                    {
                        Console.WriteLine("Najpierw musisz wykonaæ polecenie n/N!");
                    }
                    else wypisz_wiersze();
                    break;
                case 'q':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Proszê podaæ odpowiednie polecenie!");
                    break;
            }
            return exit;
        }

        public void wczytaj_macierz()
        {
            
            Console.WriteLine("Wczytuje macierz");
            Console.WriteLine("Podaj n:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj m:");
            m = int.Parse(Console.ReadLine());
             arr = new double[n,m];
            for (int i = 0; i<n; i++)
            {
                Console.WriteLine("Podaj elementy wiersza nr " + i+"; ka¿dy element zatwierdŸ wciskaj¹c enter");
                for (int j=0; j < m; j++)
                {
                    arr[i,j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Wczytano tablice!");
            for (int i =0; i<n; i++)
            {
                for (int j=0; j<m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void wypisz_wiersze()
        {
            Console.WriteLine("Wypisuje wiersze");
            double sum = 0;
            for (int i=0; i<n; i++)
            {
                for (int j = 0; j < m; j++)
                    sum += arr[i, j];
                Console.WriteLine("Suma dla wiersza nr " + i + " wynosi: " + sum);
                sum = 0;
            }
        }


        public void wypisz_kolumny()
        {
            Console.WriteLine("Wypisuje kolumny");
            double sum = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    sum += arr[j,i];
                Console.WriteLine("Suma dla wiersza nr " + i + " wynosi: " + sum);
                sum = 0;
            }
        }
    }

}
