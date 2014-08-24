/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByError.Internazional.Lang
{
    /// <summary>
    /// Polish language resources
    /// </summary>
    public class Polish
    {
        /// <summary>
        /// Resource container
        /// </summary>
        public System.Collections.Hashtable Resource { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Polish()
        {
            Resource = new System.Collections.Hashtable();
            initialize();
        }

        /// <summary>
        /// Resource initializer
        /// </summary>
        private void initialize()
        {
            Resource["r1"] = "NBN C#";
            Resource["r2"] = "Informacje o programie";
            Resource["r3"] = "Foldery aplikacji";
            Resource["r4"] = "Główny folder";
            Resource["r5"] = "Folder logów aplikacji";
            Resource["r6"] = "Folder ustawień aplikacji";
            Resource["r7"] = "Folder danych aplikacji";
            Resource["r8"] = "Ustawienia";
            Resource["r9"] = "Historia";
            Resource["r10"] = "Wyjdź";
            Resource["r11"] = "Przykładowe dane";
            Resource["r12"] = "Pomoc";
            Resource["r13"] = "Logi aplikacji";
            Resource["r14"] = "Wyślij wiadomość do autora";
            Resource["r15"] = "Wczytaj dane z pliku";
            Resource["r16"] = "Uruchom uczenie";
            Resource["r17"] = "Zapisz wykres";
            Resource["r18"] = "Ustawienia";
            Resource["r19"] = "Historia";
            Resource["r20"] = "Zamknij";
            Resource["r21"] = "Zapisz wykres";
            Resource["r22"] = "Przykładowy wykres";
            Resource["r23"] = "Iteracje";
            Resource["r24"] = "RMSE";
            Resource["r25"] = "Bitmapa";
            Resource["r26"] = "Zapisywanie wykresu";
            Resource["r27"] = "Wykres został zapisany jako: ";
            Resource["r28"] = "Wykres nie został zapisany.";
            Resource["r29"] = "Błąd uczenia: {0}, błąd testowania: {1}, dopuszczalny błąd: {2}";
            Resource["r30"] = "Zapisz do pliku";
            Resource["r31"] = "Wyślij pocztą";
            Resource["r32"] = "Konsola uczenia sieci neuronowej";
            Resource["r33"] = "Plik tekstowy";
            Resource["r34"] = "Wysyłanie zapisu uczenia na e-mail";
            Resource["r35"] = "Zapis uczenia sieci neuronowej w NBN C#";
            Resource["r36"] = "OK";
            Resource["r37"] = "Podaj adres e-mail";
            Resource["r38"] = "Aplikacja NBN C#";
            Resource["r39"] = "Opcje";
            Resource["r40"] = "Zapisz wykres do pliku";
            Resource["r41"] = "Zapisz wagi do pliku";
            Resource["r42"] = "Zapisz jako PDF";
            Resource["r43"] = "Poprzedni";
            Resource["r44"] = "Następny";
            Resource["r45"] = "Zamknij";
            Resource["r46"] = "Wagi";
            Resource["r47"] = "Wykres";
            Resource["r48"] = "Zapisz wykres";
            Resource["r49"] = "Usuń zaznaczony zapis uczenia";
            Resource["r50"] = "Historia";
            Resource["r51"] = "Zapisz wykres";
            Resource["r52"] = "Historia uczenia";
            Resource["r53"] = "Próba uczenia numer ";
            Resource["r54"] = "Nie odczytano liczby wzorców użytych do uczenia.";
            Resource["r55"] = "Zapis uczenia został załadowany.";
            Resource["r56"] = "RMSE";
            Resource["r57"] = "Iteracje";
            Resource["r58"] = "Bitmapa";
            Resource["r59"] = "Zapisz";
            Resource["r60"] = "Wykres został zapisany jako: ";
            Resource["r61"] = "Wykres nie został zapisany.";
            Resource["r62"] = "Plik tekstowy";
            Resource["r63"] = "Zapisz";
            Resource["r64"] = "Wagi zostały zapisane do pliku: ";
            Resource["r65"] = "Wagi nie zostały zapisane do pliku.";
            Resource["r66"] = "Czy chcesz usunąć zaznaczony zapis uczenia?";
            Resource["r67"] = "Usuwanie";
            Resource["r68"] = "Plik PDF";
            Resource["r69"] = "Zapisano jako: ";
            Resource["r70"] = "Plik nie został zapisany.";
            Resource["r71"] = "Logi aplikacji";
            Resource["r72"] = "Zgłoś błędy";
            Resource["r73"] = "Dziękuję za informacje.";
            Resource["r74"] = "Logi aplikacji NBN C# - uczenie sieci neuronowej";
            Resource["r75"] = "Temat wiadomośći:";
            Resource["r76"] = "Wiadomość:";
            Resource["r77"] = "Wysyłanie wiadomośći e-mail";
            Resource["r78"] = "Wiadomość została wysłana.";
            Resource["r79"] = "Ogólne";
            Resource["r80"] = "Baza";
            Resource["r81"] = "Usuń całą historię uczenia";
            Resource["r82"] = "Usuń wszystkie logi";
            Resource["r83"] = "Liczba prób uczenia: ";
            Resource["r84"] = "Zapisywanie wyników uczenia:";
            Resource["r85"] = "Pokazuj okno konsoli:";
            Resource["r86"] = "Folder danych aplikacji";
            Resource["r87"] = "Opcje uczenia sieci neuronowej";
            Resource["r88"] = "Skala";
            Resource["r89"] = "Maksymalny błąd uczenia";
            Resource["r90"] = "Maksymalna liczba iteracji";
            Resource["r91"] = "MUH - górna granica MU";
            Resource["r92"] = "MUL - dolna granica MU";
            Resource["r93"] = "MU - określa jak bardzo wagi się zmieniają podczas każdej iteracji";
            Resource["r94"] = "Zapisz zmiany";
            Resource["r95"] = "Wczytaj ustawienia domyślne";
            Resource["r96"] = "Zamknij";
            Resource["r97"] = "Zmiana języka";
            Resource["r98"] = "Ustawienia aplikacji";
            Resource["r99"] = "Usuń wszystkie logi";
            Resource["r100"] = "Usuń zapisy uczenia";
            Resource["r101"] = "Logi zostały wyczyszczone";
            Resource["r102"] = "Logi nie zostały wyczyszczone";
            Resource["r103"] = "Zapisy uczenia zostały usunięte.";
            Resource["r104"] = "Zapisy uczenia nie zostały usunięte";
            Resource["r105"] = "Czy jesteś pewien, że chcesz usunąć wszystkie zapisy uczenia sieci neuronowej?";
            Resource["r106"] = "Usuwanie";
            Resource["r107"] = "Czy jesteś pewien, że chcesz wczytac ustawienia domyślne?";
            Resource["r108"] = "Ustawienia";
            Resource["r109"] = "O programie";
            Resource["r110"] = "Wersja";
            Resource["r111"] = "Wersja";
            Resource["r112"] = "Autor";
            Resource["r113"] = "Wydawca";
            Resource["r114"] = "Opis";
            Resource["r115"] = "Zamknij";
            Resource["r116"] = "O programie";
            Resource["r117"] = "NBN C# - wynik uczenia sieci neuronowej";
            Resource["r118"] = "Uczenie sieci neuronowej za pomocą algorytmu NBN C#";
            Resource["r119"] = "...ponieważ tylko dobry kod się liczy.";
            Resource["r120"] = "C#, NBN, neuron, uczenie, sieć, nbn c#";
            Resource["r121"] = "Spis treści";
            Resource["r122"] = "Wykres przebiegu uczenia";
            Resource["r123"] = "Informacje na temat sieci neuronowej";
            Resource["r124"] = "Nazwa parametru";
            Resource["r125"] = "Wartość parametru";
            Resource["r126"] = "Wagi otrzymane w procesie uczenia";
            Resource["r127"] = "Wagi otrzymane w procesie uczenia dla: ";
            Resource["r128"] = "Wagi otrzymane z uczenia dla próby nr: ";
            Resource["r129"] = "Numer wagi";
            Resource["r130"] = "Waga";
            Resource["r131"] = "Wykres przebiegu uczenia";
            Resource["r132"] = "Wykres przebiegu uczenia dla";
            Resource["r133"] = "Data utworzenia: ";
            Resource["r134"] = "Dane wejściowe";
            Resource["r135"] = "Błąd zliczania w metodzie countId w Manager";
            Resource["r136"] = "Połączenie do bazy SQLite jest uszkodzone.";
            Resource["r137"] = "Błąd wykonania zapytania: ";
            Resource["r138"] = "Błąd podczas oczyszczania bazy.";
            Resource["r139"] = "SQLite: ";
            Resource["r140"] = "Powstał błąd operacji w metodzie execute() w DatabaseManager: ";
            Resource["r141"] = "Błąd powstał w metodzie execute() w DatabaseManager: ";
            Resource["r142"] = "Nie wykonano polecenia VACUUM w DatabaseManager. ";
            Resource["r143"] = "SQLite: ";
            Resource["r144"] = "Przerwane";
            Resource["r145"] = "Nie można otworzyć bazy";
            Resource["r146"] = "Plik bazy jest uszkodzony";
            Resource["r147"] = "Dostęp do bazy jest ograniczony - zamknięty plik";
            Resource["r148"] = "Zabrakło pamięci.";
            Resource["r149"] = "Nie odnaleziono pliku bazy";
            Resource["r150"] = "Brak uprawnień do bazy";
            Resource["r151"] = "Próba pisania do bazy w trybie tylko do odczytu";
            Resource["r152"] = "Struktura bazy jest nieprawidłowa";
            Resource["r153"] = "Zapytanie SQL jest niepoprawne lub nie odnaleziono pliku bazy. Zapytanie: ";
            Resource["r154"] = "Baza jest pusta";
            Resource["r155"] = "Otwieranie pliku";
            Resource["r156"] = "Zapisywanie pliku";
            Resource["r157"] = "Wybieranie folderu";
            Resource["r158"] = "Nie zapisuj";
            Resource["r159"] = "Zapisuj wyniki uczenia";
            Resource["r160"] = "Nie pokazuj konsoli uczenia";
            Resource["r161"] = "Pokazuj konsolę ucznenia";
            Resource["r162"] = "Zapisz jako PDF z danymi wejściowymi";
            Resource["r163"] = "Dane nie zostały wczytane, sprawdź format pliku.";
            Resource["r164"] = "Dane zostały wczytane z pliku: ";
            Resource["r165"] = "Wybierz dane wejściowe";
            Resource["r166"] = "Dane wejściowe";
            Resource["r167"] = "Uczenie - {0}";
            Resource["r168"] = "Testowanie - {0}";
            Resource["r169"] = "OK";
            Resource["r170"] = "porażka";
            Resource["r171"] = "Średni czas uczenia: {0} i średni czas testowania: {1}";
            Resource["r172"] = "Wskaźnik sukcesu: {0}";
            Resource["r173"] = "Usuń wszystkie logi";
            Resource["r174"] = "Usuwanie logów";
            Resource["r175"] = "Czy chcesz usunąć wszystkie logi aplikacji?";
            Resource["r176"] = "Liczba neuronów";
            Resource["r177"] = "Instrukcja obsługi";
            Resource["r178"] = "Zapisz wagi";
            Resource["r179"] = "Badania";
            Resource["r180"] = "Uruchom dla wszystkich danych przykładowych";

            Resource["r181"] = "Liczba neuronów";
            Resource["r182"] = "Próba uczenia nr: ";
            Resource["r183"]= "SSE nr {0} = {1}";
            Resource["r184"] = "Próba uczenia nr: ";
            Resource["r185"] = "RMSE nr {0} = {1}";
            Resource["r186"] = "Nie zaznaczono nic na liście.";
            Resource["r187"] = "Za chwilę rozpocznie się uczenie dla {0} prób z danymi.";
            Resource["r188"] = "Zatrzymywanie...";
            Resource["r189"] = "Zaczekaj na zakończenie bieżącego zadania.";
            Resource["r190"] = "Wskaż plik danych uczących";
            Resource["r191"] = "Dane uczące";
            Resource["r192"] = "Zaznacz ilość treningów";
            Resource["r193"] = "Zadanie zakończone";
            Resource["r194"] = "Wyniki badania";
            Resource["r195"] = "Anulowano";
            Resource["r196"] = "Nie wybrano pliku lub plik nie istnieje.";
            Resource["r197"] = "Badania";
            Resource["r198"] = "Uruchom dla  danych przykładowych";
            Resource["r199"] = "Zbadaj uczenie sieci";
            Resource["r200"] = "Zatrzymaj badanie";
            Resource["r201"] = "Liczba neuronów";
            Resource["r202"] = "Kopiuj do schowka";
            Resource["r203"] = "Dane uczące";
            Resource["r204"] = "Liczba neuronów";
            Resource["r205"] = "Liczba prób uczenia";
            Resource["r206"] = "Średnie RMSE testowania";
            Resource["r207"] = "Średni czas uczenia";
            Resource["r208"] = "Średni czas testowania";
            Resource["r209"] = "Kopiuj do notatnika";
            Resource["r210"] = "Średnie RMSE uczenia";
            Resource["r211"] = "Filtruj według liczby neuronów";
            Resource["r212"] = "10 i więcej neuronów";
            Resource["r213"] = "9 neuronów";
            Resource["r214"] = "8 neuronów";
            Resource["r215"] = "7 neuronów";
            Resource["r216"] = "6 neuronów";
            Resource["r217"] = "5 neuronów";
            Resource["r218"] = "4 neurony";
            Resource["r219"] = "3 neurony";
            Resource["r220"] = "2 neurony";
            Resource["r221"] = "Wszystkie wyniki";
            Resource["r222"] = "Filtruj według RMSE";
            Resource["r223"] = "RMSE poniżej 0.0001";
            Resource["r224"] = "RMSE poniżej 0.001";
            Resource["r225"] = "RMSE poniżej 0.01";
            Resource["r226"] = "RMSE poniżej 0.1";
            Resource["r227"] = "RMSE poniżej 0";
            Resource["r228"] = "Wszystkie";
            Resource["r229"] = "Historia ({0})";
            Resource["r230"] = "RMSE uczenia: {0} (średnie)";
            Resource["r231"] = "RMSE testowania: {0} (średnie)";
            Resource["r232"] = "Średni czas uczenia: {0}, Średni czas testowania: {1}";
            Resource["r233"] = "W treningu dla danych z: {0} użyto następującą ilość neuronów: {1}";
            Resource["r234"] = "Gotowe";
            Resource["r235"] = "Ładowanie";
            Resource["r236"] = "Zmiana adresu";
            Resource["r237"] = "Instrukcja obsługi";
            Resource["r238"] = "2 neurony";
            Resource["r239"] = "Ile maksymalnie neuronów może mieć sieć?";
            Resource["r240"] = "3 neurony";
            Resource["r241"] = "4 neurony";
            Resource["r242"] = "7 neuronów";
            Resource["r243"] = "6 neuronów";
            Resource["r244"] = "5 neuronów";
            Resource["r245"] = "10 neuronów";
            Resource["r246"] = "9 neuronów";
            Resource["r247"] = "8 neuronów";
            Resource["r248"] = "Anuluj";
            Resource["r249"] = "Maksymalna liczba neuronów";
            Resource["r250"] = "Wybierz liczbę powtórzeń:";
            Resource["r251"] = "Wybór liczby powtórzeń";
            Resource["r252"] = "Liczba powtórzeń dla każdego pliku:";
            Resource["r253"] = "Maksymalna liczba neuronów ";
            Resource["r254"] = "jaka może zostać użyta do testów:";
            Resource["r255"] = "Lista plików biorących udział w badaniu:";
            Resource["r256"] = "Uruchom";
            Resource["r257"] = "Generuj PDF dla każdego treningu";
            Resource["r258"] = "Wskaż folder z plikami";
            Resource["r259"] = "Wczytaj przykłady";
            Resource["r260"] = "Badanie uczenia sztucznej sieci neuronowej";
            Resource["r261"] = "Pobrano {0} z {1}";
            Resource["r262"] = "Wczytywanie przykładów rozpoczęte.";
            Resource["r263"] = "Zaczekaj na zakończenie operacji wczytywania przykładów.";
            Resource["r264"] = "Dane uczące: {0}\r\nLiczba neuronów: {1}\r\nLiczba prób: {2}\r\nŚrednie RMSE uczenia: {3}\r\nŚrednie RMSE testowania: {4}\r\nŚredni czas uczenia: {5}\r\nŚredni czas testowania: {6}\r\n\r\n";
            Resource["r265"] = "Implementacja algorytmu NBN służącego do uczenia sieci neuronowej wraz z jego modyfikacjami.";
        }
    }
}
