using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Globalization;

public class Exchange
{
    private HttpClient cliente;
    private static Exchange _instance;


    private Exchange(){
        cliente = new HttpClient();

        var chave = "ded3b7a7ee0a3d0ba265b002";//puxar de um .env

        cliente.BaseAddress = new Uri($"https://v6.exchangerate-api.com/v6/{chave}/");
        cliente.DefaultRequestHeaders.Accept.Clear();
        cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static Exchange GetInstance()
    {
        if (_instance == null) _instance = new Exchange();
        return _instance;
    }

    public async Task<(double, double)> Converte ( string origem, string destino, double valor)
    {
        var requisicao = $"pair/{origem}/{destino}/{valor.ToString("N", CultureInfo.CreateSpecificCulture("en-US"))}";

        HttpResponseMessage resposta = await cliente.GetAsync(requisicao);

        if (resposta.IsSuccessStatusCode) {
            API_Obj? json = await resposta.Content.ReadFromJsonAsync<API_Obj>();

            var taxa = json.conversion_rate;
            var resultado = json.conversion_result;

            return (taxa, resultado);
        }
        throw new Exception(resposta.StatusCode.ToString());
    }
}
