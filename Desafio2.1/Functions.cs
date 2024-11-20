using System;

public class Functions
{
    public static void ValidaMoeda(String moeda, String moeda2=null)
    {
        if (moeda.Length != 3) throw new Exception("A moeda é identificada por uma cadeia de 3 caracteres!");
        if (moeda.Equals(moeda2)) throw new Exception("As moedas devem ser diferentes!");
    }

    public static void ValidaValor(double valor)
    {
        if (valor < 0) throw new Exception("O valor deve ser positivo!");
    }
}
