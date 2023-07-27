namespace Cnab.Service.DictionaryHelpers;

public class TipoSinal
{
    public static string obterTipoSinal(int tipo)
    {
        Dictionary<int, string> tipoSinal = new Dictionary<int, string>()
        {
            { 1, "+" }, // Débito - Entrada
            { 2, "-" }, // Boleto - Saída
            { 3, "-" }, // Financiamento - Saída
            { 4, "+" }, // Crédito - Entrada
            { 5, "+" }, // Recebimento Empréstimo - Entrada
            { 6, "+" }, // Vendas - Entrada
            { 7, "+" }, // Recebimento TED - Entrada
            { 8, "+" }, // Recebimento DOC - Entrada
            { 9, "-" }  // Aluguel - Saída
        };

        return tipoSinal[tipo];
    }
}

