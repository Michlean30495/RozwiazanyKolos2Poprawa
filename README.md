# Poprawa kolokwium 2 — postacie i ekwipunek

Rozwiązanie poprawy kolokwium z APBD. API postaci, przedmiotów, plecaków i tytułów, oparte na ASP.NET Core, Entity Framework Core i SQL Server.

**Kategoria:** kolokwia APBD · **Przedmiot:** APBD · **Rok akademicki:** 2024/2025

## Technologie

C#, .NET 8, ASP.NET Core, Entity Framework Core, SQL Server, migracje Code First.

## Gdzie jest kod

- [Plik projektu](./PoprawaKolokwium2/PoprawaKolokwium2/PoprawaKolokwium2.csproj): `PoprawaKolokwium2/PoprawaKolokwium2/PoprawaKolokwium2.csproj`.
- Kod aplikacji znajduje się w katalogu tego projektu.

## Uruchomienie

Wymagany jest odpowiedni .NET SDK dla projektu (.NET 8); jeśli repozytorium zawiera `global.json`, uwzględnij również wskazaną w nim wersję SDK.

Projekt wymaga dostępu do SQL Server i bazy zgodnej z modelami lub zapytaniami ćwiczenia. Skonfiguruj lokalne połączenie w ustawieniach aplikacji przed uruchomieniem.
W projekcie używany jest klucz `ConnectionStrings:Default`; migracje znajdują się w katalogu `Migrations`.

Z katalogu głównego repozytorium:

```sh
dotnet restore "PoprawaKolokwium2/PoprawaKolokwium2/PoprawaKolokwium2.csproj"
dotnet run --project "PoprawaKolokwium2/PoprawaKolokwium2/PoprawaKolokwium2.csproj"
```

## Nawigacja

[Wszystkie projekty i materiały ze studiów](https://github.com/Michlean30495)
