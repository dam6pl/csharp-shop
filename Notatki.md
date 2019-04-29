# Zajęcia 1 (24.02.2019)

Internetowe Aplikacje Biznesowe będziemy tworzyc przy pomocy technik:

- **ASP.NET Core**
- Backend: **C#**
- Frontend: **HTML5**, **CSS** (Material Desing lub Bootstrap)
- Baza danych: **SQL Server**
- Dostęp do bazy danych: **Entity Framework**
- Zapytania do bazy danych: **LinQ** lub **SQL**
- Wiodący wzorzec projektowy: **MVC (Model - View - Controller)**



## Używanie znaczników HTML w ASP.NET

W pliku `Views/Shared/_Layout.cshtml` znajduje się wzór wygladu każdej strony internetowej projeku (podobne do `Themes`, każda strone z niego dziedziczy.

W ASP.NET w warstwie `View` można do kodu HTML dodawać kod C# poprzedzając go `@`. Silnik o nazwie Razor zamienia taki kod C#, na kod HTML.

W layoucie `@RenderBody()` oznacza, że w tym miejscu jest wklejana cała zawartość strony zgodna z tym layoutem. Poniższy kod określa tytuł strony:

```c#
@{ 
  ViewBag.Title = "Home Page";
}
```

`ViewBag` lub `ViewData` to jest taki "listonosz", który przenosi dane, pomiędzy kontrolerem a widokiem. Potrafi też przenosić dane między widokiem a layoutem.

1. File => New Project => Zakładka Website  => ASP.NET (Razor v3) => Web application.
2. Zmień kod głównego layoutu aplikacji w pliku `Views/Shared/_Layout.cshtml`.
3. Zmień stron głównej storny aplikacji w pliku `Views/Home/Index.cshtml`.



## Nauczanie przez projekt

Przed realizacją projektu należy:

- przejrzeć stronę https://material.io/
- przejrzeć stronę https://materializecss.com/



## Procedura tworzenia solucji

**Solucja** to zbiór projektów logicznie ze sobą powiązanych.

1. File => New Project => Other Project Types => Blank Solution o nazwie Firma
2. PPM na Solution "Firma" i Add => New Project => ASP.NET Core Web Application

Firma.PortalWWW to aplikacja internetowa dla klientów firmy, Firma.Intranet to aplikacja internetowa dla pracowników tej firmy.

3. PPM na Firma.PortalWWW i wybierz `Set as startup project` (decydujemy który projekt będzie się kompilował).



## Procedura tworzenia layoutu zgodnego z Material Design

Material Design to wzorzec Google budowania nowoczesnych interfejsów, które mogą być otwoerane zarówno w przeglądarkach jak i na telefonach.

1. Ustaw projekt startowy na Firma.PortalWWW (przez najbliższe kilka procedur działamy tylko na tym projekcie).

2. Przejść do `WWWroot/lib/` i dodać katalog materialize z biblioteką.

3. Zmodyfikuj `View/Shared/_Layout.cshtml`:

   1. zmodyfikuj cały kod tego pliku wzorując się na przykładzie zawartym na stronie Materialize CSS.

   2. utwórz linki do stron. Przykładowy link:

      ```c#
      @Html.ActionLink("O Firmie", "About", "Home")
      ```




# Zajęcia 2 (07.04.2019)

## Procedura sterowania zawartością strony CMS

W aplikacjach internetowych będziemy korzystali z `EntityFrameworkCore`. Szczegóły teoretyczne dotyczące tej technologi znajdują się na stronie https://docs.microsoft.com/pl-pl/ef/core/

Pamiętamy, że w `EntityFramework` są dwa główne sposoby tworzenia bazy danych:

* Database First - najpierw tworzymy bazę, a klasy dostepowe do bzy tworzy nam framework (tak było w aplikacjach desktopowych),
* Code First - najpier wtorzymy klasy w projekcie, a potem framework sam tworzy bazę danych.

Zatem dla kazdej tabeli stworzymy jedną klasę z właściwościami jak kolumny tabeli. Po stworzeniu tabel tworzymy jedną klasę `Context`, która bedzie zawierała datasety ze wszystkimi tabelami.

Aplikacje internetowe tworzymy za pomocą wzorca projektowego MVC, który dzieli pliki aplikacji na trzy warstwy: 

* Model - zawiera klasy dostępowe do bazy danych oraz klasy logiki biznesowej.

* View - zawiera widoki czyli strony napisane w HTMLu, razem ze wstawkami C# poprzedzonymi `@` (silnik Razor)

* Controller - zawiera klasy pośredniczące między widokiem a modelem.

  

1. W Solution Explorerze ustaw jako projekt startowy `Firma.intranet`.

2. PPM na `Models` i dodać nowy folder `CMS`.

3. PPM na `CMS` i dodać klasy `Strona`, `Aktualnosc`.

4. PPM na `Models` i dodac klasę `ApplicationDbContext`.

5. Skompiluj projekt.

6. PPM na `Controller` i dodać kontroler z widokami korzystającymi z EntityFramework.

7. Edytuj `_Layout.html` i dodaj link do stron.

8. Wywołaj konsole z menu Vusial Studio `Tools` => `NuGet Package Manager` => `Package Manager Console`.

9. W konsoli wpisz kolejno polecenia:

   1. ```bash
      Add-Migration InitialCreate
      ```

   2. ```bash
      Update-Database
      ```



## Procedura zarządzania sprzedażą w intranecie

1. PPM na `Models` i dodać folder o nazwie `Sklep`.

2. W folderze `Sklep` dodaj klasy `Rodzaj` i `Towar`.

3. W konsoli wpisz kolejno polecenia:
   1. ```bash
      Add-Migration <NAZWA>
      ```

   2. ```bash
      Update-Database
      ```



# Zajęcia 3 (28.03.2019)

Ponieważ projekt Firma.Intranet oraz projekt Firma.PortalWWW będą używać co najmniej 4 tych samych klas (Strona, Aktualność, Rodzaj i Towar) zatem niezbędne jest stworzenie projektu Firma.Data, który będzie udostępniał te klasy obu projektom. Projekt który udostępnia klasy to projekt typu `Class Library (.NET Core)`

## Wspólne klasy do obsługi bazy danych

1. PPM na całą solucje i dodać projekt `Class Library (.NET Core)`
2. Dodać katalog `Data`
3. PPM na `Data` i dodać foldery `CMS` i `Sklep`.
4. W folderach przenieść klasy z Firma.Intranet.Models
5. W głównym katalogu dodać klasę `FirmaContext`
6. Z Firma.Intranet usunąć wszystkie przeniesione rzeczy.
7. W projekcie Firma.Intranet dodać Zależność do Firma.Data.
8. Poprawić błędy.



## Procedura wyświetlania danych z bazy danych

Partial View to mechanizm wyświetlania jednego widoku wewnątrz drugiego. Podczas uzywania tego mechanizmu tworzy się widok partialny a następnie osadza się go w widoku w którym ma sie wyświetlić.

1. Ustaw jako projekt startowy Firma.PortalWWW
2. Edytuj plik `appsettings.json` i dodaj do niego `ConnectionStrings` wzorowanym na wygenerowanym z Firma.Intranet.
3. PPM na Zależności i dodać Firma.Data
4. Edytuj plik `Startup.cs` i zmodyfikuj funkcje konfiguracji serwisu `ConfigureServices` wzorując się na Firma.Intranet
5. Rozwiń katolog `Views` => `Shared` i utwórz dwa widoki wyświetlający linki do stroni wyświetlający aktualności. Widoki te osadzimy w layoucie głównym.
6. W `HomeController` uzupełnik kod o dostep do `FirmaContext`

Jeżeli widok będzie wyświetlał kolekcję elementów danego typu to na początku tego widoku trzeba dodać kod:

```c#
@model IEnumerable<Firma.Data.CMS.Strona>
```

Jeżeli widok będzie wyświetlał tylko jeden element danego typu to na początku tego widoku trzeba dodac kod:

```c#
@model Firma.Data.CMS.Strona
```











