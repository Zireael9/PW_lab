/*WYWOLANIE
PojazdSilnikowy a = new PojazdSilnikowy(5);
             PojazdSilnikowy b = new PojazdKolowy(60, 15);
             PojazdSilnikowy c = new SamochodOsobowy(9, 90, 91);
             a.pokaz();
             b.pokaz();
             c.pokaz();
*/

        class PojazdSilnikowy 
        {
            protected int moc;
            public PojazdSilnikowy(int m)
            {
                moc = m;
            }

            public virtual void pokaz()
            {
                Console.WriteLine("Moc = " + moc);
            }
        }

        class PojazdKolowy : PojazdSilnikowy
        {
            protected int liczbaKol;
            public PojazdKolowy(int moc, int liczbak) : base(moc)
            {
               
                liczbaKol = liczbak;
            }

            public override void pokaz()
            {
                base.pokaz();
                Console.WriteLine("Liczba kol = " + liczbaKol);
            }

        }


        class SamochodOsobowy : PojazdKolowy
        {

            private int liczbaPasazerow;
            public SamochodOsobowy(int moc, int liczbaKol, int liczbaP) : base (moc, liczbaKol)
            {
                liczbaPasazerow = liczbaP;
            }
            public override void pokaz()
            {
                base.pokaz();
                Console.WriteLine("Liczba pasazerow = " + liczbaPasazerow);
            }

        }