/*
WYWOLANIE:
Beczka b1 = new Beczka(1000, 250);
            Beczka b2 = new Beczka(1500, 100);
            int a = b1 + 850;
            int b = b2 + 400;
            bool c = b1 * b2;
            Console.WriteLine(c);

*/
namespace PW1
{
    class Beczka
    {
        private int pojemnosc;
        private int zawartosc;

        public Beczka(int poj, int zaw)
        {
            pojemnosc = poj;
            zawartosc = zaw;
        }

        public static int operator +(Beczka b, int a)
        {
            int ret = 0;
            if (b.zawartosc + a< b.pojemnosc)
            {
                ret = 0;
                b.zawartosc += a;
            }
            else
            {
                ret = a + b.zawartosc - b.pojemnosc;
                b.zawartosc = b.pojemnosc;
            }
            return ret;
        }

        public static bool operator * (Beczka b1, Beczka b2)
        {
            return (b1.zawartosc>b2.zawartosc);
        }
    }
}