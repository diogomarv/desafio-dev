using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Enums
{
    public enum ETipo
    {
        [Description("Débito")]
        Debito = 1,

        [Description("Boleto")]
        Boleto = 2,

        [Description("Financiamento")]
        Financiamento = 3,

        [Description("Crédito")]
        Credito = 4,

        [Description("Recebimento Empréstimo")]
        RecebimentoEmprestimo = 5,

        [Description("Vendas")]
        Vendas = 6,

        [Description("Recebimento TED")]
        RecebimentoTED = 7,

        [Description("Recebimento DOC")]
        RecebimentoDOC = 8,

        [Description("Aluguel")]
        Aluguel = 9,
    }
}
