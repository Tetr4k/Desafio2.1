// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

do
{
    try
    {
        Console.Write("Moeda origem: ");
        var origem = Console.ReadLine().Trim().ToUpper();
        if (origem.Length == 0) break;

        Functions.ValidaMoeda(origem);

        Console.Write("Moeda destino: ");
        var destino = Console.ReadLine().Trim().ToUpper();

        Functions.ValidaMoeda(origem, destino);

        Console.Write("Valor: ");
        var valor = Double.Parse(Console.ReadLine().Trim());

        Functions.ValidaValor(valor);

        Console.WriteLine();

        var (taxa, resultado) = Exchange.GetInstance().Converte(origem, destino, valor).Result;

        Console.WriteLine($"{origem} {valor} => {destino} {resultado:F2}");
        Console.WriteLine($"Taxa: {taxa:F6}");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
} while (true);