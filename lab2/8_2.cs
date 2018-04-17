using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gry
{
    ///WYWOLANIE:
    ///     Labirynt l = new Labirynt();
    ///    l.play();
    ///
    /// 
    /// <summary>
    /// 2-pole poczatkowe
    /// 3- cel
    /// 1-korytarz
    /// </summary>
    class Labirynt
    {
        int x=0;
        int y=0;

        int xx = 3;
        int yy = 2;

        bool gameover = false;
        int[,] pole = new int[5, 5]
        {
            {1,1,0,0,0},
            { 0,1,1,0,0},
            { 1,1,1,1,1},
            { 1,0,1,0,0},
            { 1,0,0,0,0}
        };


        public Labirynt()
        {

        }

        public void showBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i==0 && j==0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if
                        (i == xx && j == yy)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    if (i==x && j == y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write(pole[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }


        private bool warunki(int a, int b)
        {
            if (a >= 5 || b >= 5 || a < 0 || b < 0) return false;
            if (pole[a,b] == 0) return false;
            return true;
        }

        public bool makeAMove(int a, int b)
        {
           

            if (!warunki(a,b))
            {
                return false;
            }
            else
            {
                x = a;
                y = b;
                Console.Clear();
                showBoard();
                return true;
            }
        }


        public void play()
        {
            ConsoleKeyInfo key;
            Console.CursorVisible = false;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            showBoard();
            while (!gameover)
            {
                int a = x;
                int b = y;
                bool movemade = false;
                key = Console.ReadKey();
                if (ConsoleKey.UpArrow == key.Key)
                {
                    a = x - 1;
                    
                }
                else if (ConsoleKey.DownArrow == key.Key)
                {
                    a = x + 1;
                }
                else if (ConsoleKey.LeftArrow == key.Key)
                {
                    b = y - 1;
                }
                else if (ConsoleKey.RightArrow == key.Key)
                {
                    b = y + 1;
                }
                movemade = makeAMove(a,b);
                if (movemade)
                {

                   // Console.CursorLeft = x;
                    //Console.CursorTop = y;
                }

                if (x == xx && y == yy) gameover = true;
            }
        }


    }


}