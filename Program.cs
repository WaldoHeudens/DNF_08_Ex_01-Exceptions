using Bank;

// 1. try/catch/finally: een riskante bewerking afschermen.
int[] scores = [10, 20, 30];

try
{
    Console.WriteLine("We lezen index 5 uit een array van 3 elementen.");
    Console.WriteLine(scores[5]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Opgevangen: {ex.Message}");
}
finally
{
    Console.WriteLine("Het finally-blok draait altijd, ook na een exception.");
}

// 2. Meerdere catch-blokken: enkel opvangen wat je verwacht.
Console.WriteLine();
foreach (string invoer in new[] { "42", "honderd" })
{
    try
    {
        int getal = int.Parse(invoer);
        Console.WriteLine($"'{invoer}' geparsed naar {getal}.");
    }
    catch (FormatException)
    {
        Console.WriteLine($"'{invoer}' is geen geldig getal.");
    }
}

// 3. Zelf een exception gooien, plus exception filters (when).
Console.WriteLine();
var rekening = new Rekening(saldo: 100m);

foreach (decimal bedrag in new[] { 30m, 200m, 500m, -5m })
{
    try
    {
        rekening.NeemOp(bedrag);
        Console.WriteLine($"Opname van {bedrag:0.00} gelukt. Nieuw saldo: {rekening.Saldo:0.00}.");
    }
    // Exception filter: dit blok vangt enkel als de when-voorwaarde waar is.
    catch (OnvoldoendeSaldoException ex) when (ex.Tekort <= 150m)
    {
        Console.WriteLine($"Klein tekort van {ex.Tekort:0.00}. Probeer een lager bedrag.");
    }
    catch (OnvoldoendeSaldoException ex)
    {
        Console.WriteLine($"Groot tekort van {ex.Tekort:0.00}. Opname geweigerd.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Ongeldig bedrag voor parameter '{ex.ParamName}'.");
    }
}
