using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/*WYWOLANIE:
Random r = new Random();
Loteria l = new Loteria(r);
Gracz g1 = new Gracz(r, l, 1);
Gracz g2 = new Gracz(r, l, 2);
Gracz g3 = new Gracz(r, l, 3);
while (!(g1.winning() || g2.winning() || g3.winning()))
{
    g1.graj();
    g2.graj();
    g3.graj();

    l.Losuj();

}
g1.wypiszPunkty();
g2.wypiszPunkty();
g3.wypiszPunkty();
*/
/// 
/// </summary>
namespace Lab
{

    class Gracz
    {
        private Random rand;
        private Loteria lot;
        private int punkty;
        private int nr;
        public Gracz(Random r, Loteria l, int n) {
            rand = r;
            lot = l;
            punkty = 0;
            nr = n;
        }
        public void wypiszPunkty()
        {
            Console.WriteLine("Gracz nr "+ nr+" zdoby³ "+punkty+" punktów");
        }

        public void zaklad()
        {
            punkty++;
        }

        public void graj()
        {
            int r = rand.Next(0,2);
            if (r == 0)
            {
                lot.L1 += zaklad;
            }
            else if (r == 1)
            {
                lot.L2 += zaklad;
            }
            else
            {
                lot.L3 += zaklad;
            }
        }

        public bool winning()
        {
            if (punkty == 100)
            {
                Console.WriteLine("Gracz " + nr+" wygra³!");
                return true;
            }
            return false;
        }
    }


    class Loteria
    {

        private Random rand;
        
        public event Action L1;
        public event Action L2;
        public event Action L3;
        public Random Rand { get => rand;}

        public Loteria(Random r)
        {
            rand = r;
        }


        public void Losuj()
        {
            int r = rand.Next(0,2);
            if (r == 0) L1?.Invoke();
            else if (r == 1) L2?.Invoke();
            else  L3?.Invoke();
            clear();

        }


        public void clear()
        {
            L1 = L2 = L3 = null;
        }
    }
}
