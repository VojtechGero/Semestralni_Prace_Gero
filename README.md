# ALD Semestrální Práce 2022/23

Tento kód implementuje algoritmus pro generování náhodného světa pomocí dlaždicového systému. Svět je reprezentován dvourozměrným polem dlaždic. Algoritmus se zaměřuje na vytváření struktury světa pomocí těchto dlaždic, přičemž každá dlaždice musí navazovat na sousední dlaždice.

Aplikace je realizována v jazyce C# pomocí UI frameworku Windows Forms

Závislosti pro spuštění:
[.NET Desktop Runtime 8.0.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Komponenty kódu

### Semestralni_Prace - Hlavní formulář

`show(Tile[,] field)` - Zobrazuje dlaždice ve formuláři na základě aktuálního stavu světa.

`getField(int size)` - Inicializuje pole dlaždic o dané velikosti a vrací prázdnou plochu.

`check(Tile[,] field, int blok, Tile t)` - Ověřuje, zda lze dlaždici t umístit na pozici podle pravidel návaznosti.

`generator(Tile[,] field, Tile[] opts, int blok)` - Rekurzivně generuje svět pomocí dlaždic z pole možných dlaždic.

`closeAll()` - Zajišťuje uzavření všech PictureBox prvků ve formuláři.

`Generate_Button_Click(object sender, EventArgs e)` - Zajišťuje funkci tlačítka pro generování nového světa.

### Tile - Třída reprezentující dlaždici

`tiletype`: Obrázek představující vizuální reprezentaci dlaždice ([Resources](https://github.com/VojtechGero/Semestralni_Prace_Gero_Hejsek/tree/master/Semestralni_prace/Resources)).

`adj`: Pole boolean hodnot, které reprezentují návaznost stran

`add(Tile[,] field, int blok)` - Přidá dlaždici do světa na zadanou pozici.

`remove(Tile[,] field, int blok)` - Odebere dlaždici ze světa na zadané pozici.

`getTiles()` - Statická metoda vrací pole dostupných dlaždic s jejich vlastnostmi (návaznost a vizuální reprezentace).

### Postup generování světa

1. Inicializace pole `Tile[,]` představujícího svět.
2. Volání metody `generator()` dokud nenaplníme pole.
    1. Ověření zda se číslo bloku nachází ve světě
    2. Vytvoření pole možných dlaždic
    3. Náhodné prohození dlaždic pomocí `Random.Shared.Shuffle()` (důvod proč jsme zvolili .NET 8)
    4. Iterace přes pole `shuffled` s možnými dlaždicemi
        1. Pokud metoda `check()` vyhodnotí dlaždici jako kompatibilní, přidáme ji do světa a rekurzivně voláme metodu `generator()`
        2. Pokud rekurzivně volaná metoda vrátí platné pole, pak toto aktualizované pole vrátíme, v opačném případě dlaždici z pole odstraníme, vrátíme se a pokusíme se o jinou kombinaci dlaždic

### Poznámky a použití:

Velikost světa je nastavena na konstantní hodnotu 10.

Dlaždice jsou reprezentovány obrázky a okolní dlaždice jsou zohledněny pomocí pole `adj` podle kterého je vyhodnocená návaznost.

Před každým generováním světa je volána metoda `closeAll()`, která odstraní všechny předchozí dlaždice z formuláře.

Generování světa provedete tlačítkem `Generuj` v horní části okna, zbytek okna bude vyplněn generovaným světem.
