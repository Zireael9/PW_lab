# PW_lab
Rozwiązanie zadań z przedmiotu Programowanie Wizualne (Informatyka, PUT)


**LAB1** - opis w dokumencie w folderze

**LAB2**

PNZ5:6
Opracować program, który sumuje wiersze lub kolumny macierzy. Program akceptuje 4 polecenia:
1. N | n : wczytuje macierz elementów typu double o  m wierszach i n kolumnach 
       (m, n < 20),
2. W | w : wyprowadza sumy elementów z poszczególnych wierszy,
3. K | k : wyprowadza sumy elementów z poszczególnych kolumn,
4. Q | q : kończy działanie.
Polecenia W i K nie powinny być realizowane gdy nie zostało uprzednio wykonane polecenie N.

> Wszystko ponizej to zadania PO

7:2
Opracować program zawierający definicję klasy Tekst, która zawiera składową prywatną napis typu string. W klasie tej zdefiniować 2 konstruktory:
bezargumentowy : nadaje składowej napis wartość ".",
jednoargumentowy : argument ma typ string : przypisać go 
  składowej napis,
            oraz właściwość Napis umożliwiającą odczyt składowej napis oraz zapis nowej  
            wartości tej składowej, gdy ta nowa wartość ma przynajmniej 3 znaki.
W programie głównym należy utworzyć dwa obiekty klasy Tekst. Obiekt T1 za pomocą konstruktora bezargumentowego, obiekt T2 za pomocą konstruktora jednoargumentowego - argumentem ma być słowo "Polewka". Następnie program zmienia wartość składowej napis obiektu T1 na "Kapuśniak", a obiektu T2 na "OK", po czym wyprowadza na monitor wartości składowych napis obu tych obiektów.
8:2
Opracować program gry Labirynt. Program wyświetla plan labiryntu z zaznaczoną odrębnym kolorem pozycją początkową pionka i polem docelowym. Następnie program umożliwia przesuwanie pionka za pomocą klawiszy strzałek nie dopuszczając do wejścia na pole zakazane. Osiągnięcie pola docelowego kończy program.
W programie należy zdefiniować klasę plansza, która wyświetla plan labiryntu i akceptuje polecenia przekazywane za pomocą klawiszy strzałek.

**LAB3**

7:3
Opracować program, który zawiera definicję klasy Beczka o składowych prywatnych Pojemnosc i Zawartosc (liczby całkowite) . W klasie tej zdefiniować konstruktor dwuargumentowy oraz przeciążyć operatory + i * . 
Argumentami operatora + jest obiekt klasy Beczka i liczba  całkowita.  Wykonanie operatora polega na zwiększeniu wartości składowej Zawartosc o podaną liczbę całkowitą, o ile suma tych dwu wartości nie przekracza wartości składowej Pojemnosc (w tym przypadku wynikiem operatora jest 0). W przeciwnym razie wartość składowej Zawartosc ma się stać równa wartości składowej Pojemnosc, a wynikiem operatora jest ilość płynu, która nie zmieściła się w beczce.
Argumentami operatora * są dwa obiekty klasy Beczka - wynikiem jest wartość true, gdy  wartość składowej Zawartosc lewego argumentu jest większa lub równa wartości składowej Zawartosc prawego argumentu. W przeciwnym przypadku wynikiem jest false.
W programie głównym utworzyć dwa obiekty klasy beczka: B1 o składowych  (1000, 250) i B2 o składowych (1500, 100). Następnie (stosując zdefiniowane operatory) zwiększyć Zawartosc beczki B1  o 850, beczki B2 o 400 i sprawdzić, która beczka ma większą Zawartosc.

8:5
Opracować program realizujący makrogenerację. Dane wejściowe:

- napis wielowyrazowy (1 linia),
- ciąg wyrazów zastępowanych (1 linia),
- ciąg  wyrazów zastępujących (1 linia).
[wyrazów zastępowanych i zastępujących musi być tyle samo]
 
Zdefiniować klasę Tekst zawierający tablicę słów przechowująca ciąg wyrazów i wprowadzić dla tej klasy indeksator. W konstruktorze klasy wczytywać z konsoli ciąg wyrazów. Po przetworzeniu napisu należy wyprowadzić wynik na monitor.

Przykład:

Na Placu Czerwonym rozdają samochody
samochody rozdają 
rowery kradną

Na Placu Czerwonym kradną rowery


7:6
Zdefiniować następującą hierarchię klas.
PojazdSilnikowy<-PojazdKolowy<-SamochodOsobowy

Klasa PojazdSilnikowy zawiera składową dziedziczoną Moc, klasa PojazdKolowy składową dziedziczoną LiczbaKol, klasa SamochodOsobowy składową LiczbaPasazerow. Każda klasa posiada konstruktor o odpowiedniej liczbie argumentów, który dla klas pochodnych wywołuje konstruktor swojej klasy bazowej. W takiej hierarchii klas zdefiniować funkcję wirtualną Pokaz, która w klasie PojazdSilnikowy wyprowadza na monitor wartość składowej Moc, a w klasach pochodnych zawiera wywołanie funkcji z klasy bazowej i wyprowadzenie składowej specyficznej dla danej klasy. W programie głównym zadeklarować tablicę 12 obiektów klasy PojazdSilnikowy i wpisać do niej na dowolne pozycje kilka przykładowych obiektów klas znajdujących się w hierarchii dziedziczenia. Zakładając, że tablica ta jest w dowolny sposób wypełniona referencjami obiektów wymienionych klas wykonać dla każdego elementu tablicy funkcję Pokaz.

7:8
Opracować program, który zawiera definicję klasy Drukarka o prywatnych składowych Kolor (typu bool) i PrędkoscDruku (typu double). Składowe te należy udostępnić za pomocą właściwości - dla składowej Kolor właściwość tylko do odczytu, dla składowej PrędkośćDruku sprawdzać, czy nowa wartośc tej składowej znajduje się w przedziale [1,100]. Klasa Drukarka ma zawierać konstruktor dwuargumentowy. W klasie tej zrealizować interfejs IComparable dla porównywania obiektów klasy Drukarka. Porównanie to ma przebiegać następująco:
drukarka kolorowa jest zawsze lepsza (większa) od czarno-białej,
gdy dwie drukarki mają taką samą składową Kolor, to porównuje się prędkości druku (im większa tym lepsza).
W programie głównym utworzyć kolekcję danych List<Drukarka>, wpisać do niej kilka przykładowych obiektów klasy Drukarka, posortować te obiekty i wyprowadzić listę posortowanych obiektów.

**LAB4**

9:4
Opracować program symulujący loterię, w którą gra 3 graczy. Klasa Loteria udostępnia odpowiednią delegację i 3 zdarzenia L1, L2, L3. Każdy obiekt klasy Gracz rejestruje losowo swoją funkcję Zakład w jednym z tych zdarzeń. Następnie wykonywana jest funkcja Losowanie z klasy Loteria, która wybiera losowo jedno z wymienionych zdarzeń i zgłasza je. Gracze wygrywający otrzymują po1 punkcie – dodania punktu dokonuje funkcja Zakład. Program kończy się po uzyskaniu przez dowolnego gracza 100 punktów (wyświetlić wynik końcowy wszystkich graczy).

9:5
Zdefiniować klasę Student (Imię, Nazwisko, Album, RokUro, Semestr, Średnia) i klasę Wykładowca (Imię, Nazwisko, Semestr - przyjąć, że wykładowca prowadzi zajęcia na tylko jednym semestrze) oraz klasę Listy zawierającą  kolekcję List<Student> oraz kolekcję List<Wykładowca>.  Utworzyć obiekt klasy Listy i wczytać do niego dane z pliku SW.xml za pomocą serializacji XML. Następnie zdefiniować wyrażenia LINQ, które wyznaczają następujące dane (i wyznaczone dane wyświetlić):
a) pełne dane wszystkich studentów uporządkowane rosnąco wg. semestrów,
b) imiona i nazwiska studentów I stopnia studiów (sem. I do VII) uporządkowane malejąco wg. numerów albumów,
c) odpowiedź na pytanie, czy w zbiorze studentów (mężczyzn) są starsi niż 26 lat,
d) pełne dane studentek z VII semestru, 
e) przeciętną średnią studentów II stopnia studiów (sem. VIII - X),
f) nazwiska i imiona studentów, z którymi prowadzi zajęcia wskazany wykładowca,
g) imię i nazwisko studenta o najwyższej średniej i studenta o najniższej średniej,
h) imiona, nazwiska i nr albumu studentów podgrupowane wg. numerów semestrów.
Ponadto zapisać wyrażenia LINQ, które:
i) zmieniają wszystkim studentom numery semestrów na o 1 większe (poza studentami X semestru - dla nich wpisać nr semestru -1),
j) zmniejszają studentom o podanym imieniu numer semestru o 1,
oraz wyświetlić zmodyfikowaną kolekcję danych studentów.



9:13
Wszystkie słowa z pliku testowego E wczytać do kolekcji List<string> (każde słowo ma w niej wystąpić tylko raz, zamienić duże litery na małe) a następnie, stosując wyrażenia LINQ, wyznaczyć:
a. wszystkie słowa zaczynające się na literę s, posortowane alfabetycznie – wynik wpisać pliku s-słowa.txt,
b. wszystkie słowa o liczbie liter równej 5 posortowane alfabetycznie – wynik wpisać do pliku 5-słowa.txt,
c. słowa o złożone z 5 liter i zaczynające się na s – wpisać do pliku s5-słowa.txt (operacja na zbiorach danych),
d. minimalną, średnią i maksymalną liczbę liter w słowach zaczynających się na s - wyświetlić,
e. słowa o najmniejszej liczbie liter i słowa o największej liczbie liter spośród słów zaczynających się na s – wyświetlić.

9:7
Opracować program gry Bieg, w której dwa pionki (o różnych kolorach) posuwają się z lewej do prawej strony okna konsoli (każdy w swoim wierszu). W każdym ruchu pionek przesuwa się o losową liczbę pozycji z przedziału (-8, 12). Zakończenie gry następuje, gdy jeden z pionków osiąga cel (kolumnę 60) - komunikat sygnalizujący zakończenie należy wyświetlić poniżej pionków stosując litery takiego samego koloru jak kolor pionka - zwycięzcy. 
W programie należy zdefiniować klasę Pionek, która posiada konstruktor trójargumentowy (kolor, numer wiersza, obiekt synchronizujący) oraz funkcję Skok, która oblicza nową pozycję i wyświetla pionek synchronizując dostęp do konsoli (lock).  Dla każdego pionka należy utworzyć odrębny wątek. Kolejne ruchy pionków powinny odbywać się co 500 ms.

**LAB5**

7:9
Plik wejściowy zawiera ciąg liczb całkowitych oddzielonych spacjami. Opracować program, który z takiego pliku wejściowego (zapytać o nazwę) przepisuje do pliku wyjściowego (też zapytać o nazwę) tylko te liczby całkowite, które są większe od 137. 

8:4
Opracować program, który wyznacza histogram występowania słów w pliku (zapytać o nazwę pliku). Uporządkowany w kolejności malejącej  histogram zapisać do pliku wynikowego (zapytać o nazwę pliku). W słowach odczytywanych z pliku zamienić duże litery na małe (można wykorzystać plik testowy E). Zastosować  kolekcje parametryczne Dictionary i SortedList.

7:7
Opracować program prowadzący spis samochodów (max. 125 samochodów). Każdy samochód opisany jest za pomocą obiektu klasy zawierającej markę, rok_produkcji i cenę samochodu (składowe prywatne). Dostęp do tych składowych prywatnych umożliwiają właściwości. Program realizuje  następujące polecenia:
R : wczytanie liczby samochodów i tablicy obiektów opisujących samochody z pliku dyskowego Baza.txt,
N :  wczytanie danych opisujących samochód z konsoli i wprowadzenie ich  do kolejnej pozycji tablicy obiektów,
W : wyświetlanie informacji o wszystkich samochodach,
Z : zapis liczby samochodów i tabeli obiektów do pliku dyskowego Baza.txt,
K : zakończenie programu.
Do obsługi opcji zastosować kolekcję Dictionary<char, FunOp>.
9:4

**LAB6**

9:10
Opracować program, który na podstawie tablicy T1, zawierającej 1M liczb typu double wygenerowanych losowo, wyznacza tablicę T2, której elementy przyjmują wartości:

			T2[i] = sin2(T1[i] - 12,5) + cos2(T1[i] + 15,7)

	Obliczenie wartości elementów tablicy T2 wykonać trzy razy:
	a) sekwencyjnie za pomocą 1 wątku,
	b) współbieżnie za pomocą 2 wątków przetwarzających połówki tablicy T1
                (wykorzystać Parallel.For),
	c) współbieżnie za pomocą 1M wątków przetwarzających  tablicę T1
	    (wykorzystać Parallel.For).
	Dla każdego przypadku zmierzyć czas wykonania obliczeń i wyprowadzić te czasy 
            wyrażone w milisekundach.
9:11
Opracować program, który dla każdego z plików zawartych w katalogu Dane wyznacza liczbę wyrazów zawierających przynajmniej jedną literę 'e', stosując odpowiednie wyrażenie LINQ. Po ustaleniu tej liczby jest ona wyprowadzana na monitor razem z nazwą pliku oraz identyfikatorem wątku. Obliczenie to wykonać dwukrotnie:
	a) sekwencyjnie za pomocą 1 wątku,
	b) współbieżnie za pomocą instrukcji Parllel.ForEach.
	Dla każdego przypadku zmierzyć czas wykonania obliczeń i wyprowadzić te czasy 
            wyrażone w milisekundach.

9:7
Opracować program gry Bieg, w której dwa pionki (o różnych kolorach) posuwają się z lewej do prawej strony okna konsoli (każdy w swoim wierszu). W każdym ruchu pionek przesuwa się o losową liczbę pozycji z przedziału (-8, 12). Zakończenie gry następuje, gdy jeden z pionków osiąga cel (kolumnę 60) - komunikat sygnalizujący zakończenie należy wyświetlić poniżej pionków stosując litery takiego samego koloru jak kolor pionka - zwycięzcy. 
W programie należy zdefiniować klasę Pionek, która posiada konstruktor trójargumentowy (kolor, numer wiersza, obiekt synchronizujący) oraz funkcję Skok, która oblicza nową pozycję i wyświetla pionek synchronizując dostęp do konsoli (lock).  Dla każdego pionka należy utworzyć odrębny wątek. Kolejne ruchy pionków powinny odbywać się co 500 ms.
