List<String> text = new List<string>();
            FileInfo f = new FileInfo("Eden.txt");
            StreamReader sr = f.OpenText();
            StreamWriter sw;
            while (!sr.EndOfStream)
            {
                String[] lineCurr = sr.ReadLine().Split(' ');
                foreach (var word in lineCurr)
                {
                    if (!text.Contains(word.ToLower()))
                    {
                        text.Add(word.ToLower());
                    }
                }

            }
            sr.Close();
            //a
            sw = new StreamWriter("s-slowa.txt");
            (from slowo in text where slowo.StartsWith("s") orderby slowo ascending select slowo).ToList().ForEach(r => sw.WriteLine(r));
            sw.Close();

            //b
            sw = new StreamWriter("5-slowa.txt");
            (from slowo in text  where slowo.Length == 5 orderby slowo ascending select slowo).ToList().ForEach(r => sw.WriteLine(r));
            sw.Close();

            //c
            sw = new StreamWriter("s5-slowa.txt");
            (from slowo in text where slowo.Length == 5 && slowo.StartsWith("s") orderby slowo ascending select slowo).ToList().ForEach(r => sw.WriteLine(r));
            sw.Close();

            //d
            var maxD = (from slowo in text where slowo.StartsWith("s") select slowo.Length).Max();
            var minD = (from slowo in text where slowo.StartsWith("s")  select slowo.Length).Min();
            var avgLenD = (from slowo in text where slowo.StartsWith("s") select slowo.Length).Average();
            Console.WriteLine("Srednia dlugosc slowa(D) : "+ avgLenD);
            Console.WriteLine("Max dlugosc slowa(D) : "+ maxD);
            Console.WriteLine("Min dlugosc slowa(D) : "+ minD);

            //e
            var zapytanieE = from slowo in text  where slowo.StartsWith("s") && (slowo.Length == maxD || slowo.Length == minD) select slowo;
            foreach (var s in zapytanieE)
            {
                Console.WriteLine(s);
            }