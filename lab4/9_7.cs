public class mainBieg
    {
        public void mainB()
        {
            Random r = new Random();
            Object x = new object();
            Object x1 = new object();
            chessPiece chessPiece1 = new chessPiece(ConsoleColor.Red, 1, x, r);
            chessPiece chessPiece2 = new chessPiece(ConsoleColor.Blue, 10, x1, r);
            Thread num1 = new Thread(new ThreadStart(chessPiece1.Run));
            Thread num2 = new Thread(new ThreadStart(chessPiece2.Run));
            num1.Start();
            num2.Start();

        }
    }





    class chessPiece
    {
        public ConsoleColor color;
        public int rowNum;
        public int Y = 0;
        object obiekt_synchro;
        Random r;
        public chessPiece(ConsoleColor col, int num, object o, Random x)
        {
            this.color = col;
            this.rowNum = num;
            this.obiekt_synchro = o;
            this.r = x;
        }
        public void Skok()
        {

            lock (obiekt_synchro)
            {

                int move = r.Next(-8, 13);
                Y += move;
                if (Y < 0)
                {
                    Y = 1;
                }
                Console.CursorLeft = Y;
                Console.CursorTop = rowNum;

                Console.ForegroundColor = color;
                Console.Write("*");
            }
            System.Threading.Thread.Sleep(500);
        }
        public void Run()
        {
            while (true)
            {
                if (Y < 60)
                    Skok();
                else
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = 20;
                    Console.WriteLine("WYGRYWA {0}", this.color);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();

                }
            }
        }
    }