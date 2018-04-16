 Console.WriteLine("Podaj nazwe pliku wejsciowego :");
            String fileNameIn = Console.ReadLine();
            Console.WriteLine("Podaj nazwe pliku wyjsciowego :");
            String fileNameOut = Console.ReadLine();

            FileInfo file = new FileInfo(fileNameIn);
            StreamReader sr = file.OpenText();
            String[] listNumbers;
            ArrayList wynik = new ArrayList();


            String linia = sr.ReadLine();
            while (linia != null)
            {
                listNumbers = linia.Split(' ');
                foreach (var i in listNumbers)
                {
                    if (Int32.Parse(i) > 137)
                    {
                        wynik.Add(i);
                    }
                }
                linia = sr.ReadLine();
            }


            StreamWriter sw = new StreamWriter(fileNameOut);
            foreach (var j in wynik)
            {
                sw.Write(j + " ");
            }
            sw.Close();