            Console.WriteLine("Podan nazwe pliku wejsciwego: ");
            String inputName = Console.ReadLine();
            Console.WriteLine("Podaj nazwe pliku wyjsciowego: ");
            String outputName = Console.ReadLine();



            FileInfo fi = new FileInfo(inputName);
            StreamReader sr = fi.OpenText();

            String[] words;
            String line;
            Dictionary<String, int> dict = new Dictionary<string, int>();

            while ((line = sr.ReadLine()) != null)
            {
                words = line.Split(' ');
                foreach (String w in words)
                {
                    string word = w.ToLower();
                    if (!dict.ContainsKey(word))
                    {
                        dict.Add(word, 1);
                    }
                    else
                        dict[word]++;
                }
            }


            SortedList<int, String> sorted = new SortedList<int, String>();
            foreach (var i in dict)
            {
                if (sorted.ContainsKey(i.Value))
                {
                    sorted[i.Value] += ", " + i.Key;
                }
                else
                {
                    sorted.Add(i.Value, i.Key);
                }
            }

            StreamWriter outputFile = new StreamWriter(outputName);
            foreach (var i in sorted.Reverse())
            {
                Console.WriteLine("Wyst¹pienia: {0}, {1}", i.Key, i.Value);
                outputFile.WriteLine("Wyst¹pienia: {0}, {1}", i.Key, i.Value);
            }

            outputFile.Close();
            sr.Close();