class ZadaniePierwsze
    {
        Random rand;
        Stopwatch watch;
        const int milion = 1000000;
        double[] arr = new double[milion];
        double[] arr2 = new double[milion];
        public ZadaniePierwsze()
        {
            rand = new Random();
            watch = new Stopwatch();
            initTable();
        }


        void initTable()
        {
            for (int i=0; i < milion; i++)
            {
                arr[i] = rand.NextDouble();
            }
        }

        public void startWatch()
        {
            watch.Reset();
            watch.Start();
        }

        public void stopWatch()
        {
            watch.Stop();
        }

        public long getElapsedTime()
        {
            long time = watch.ElapsedMilliseconds;
            return time;
        }

        public void programniesynchr()
        {
            int i = 0;
            startWatch();
            for (i=0; i<milion; i++)
            {
                arr2[i] = Math.Pow(Math.Sin(arr[i] - 12.5),2) + Math.Pow(Math.Cos(arr[i] + 15.7),2);
            }
            stopWatch();
            long result = getElapsedTime();
            Console.WriteLine("Elapsed time=" + result.ToString());
        }


        public void programdrugi()
        {
            watch.Reset();
            startWatch();
            Parallel.For(0, 2, i =>
             {
                for (int j = i*milion/2; j < (i+1)* milion/2; j++)
                {
                    arr2[j] = Math.Pow(Math.Sin(arr[j] - 12.5), 2) + Math.Pow(Math.Cos(arr[j] + 15.7), 2);
                }

             });

            stopWatch();
            long result = getElapsedTime();
            Console.WriteLine("Elapsed time=" + result.ToString());
        }


        public void programtrzeci()
        {
            
            startWatch();
            Parallel.For(0, milion, i =>
            {
                arr2[i] = Math.Pow(Math.Sin(arr[i] - 12.5), 2) + Math.Pow(Math.Cos(arr[i] + 15.7), 2);
            });

            stopWatch();
            long result = getElapsedTime();
            Console.WriteLine("Elapsed time=" + result.ToString());
        }

    }