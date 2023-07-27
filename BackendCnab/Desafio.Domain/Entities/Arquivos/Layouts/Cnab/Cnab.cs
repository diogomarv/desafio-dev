using Desafio.Domain.Enums;
using System;

namespace Desafio.Domain.Entities.Arquivos.Layouts.Cnab;

public class Cnab : BaseEntity
{
    public ETipo Tipo { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public string Cpf { get; set; }
    public string Cartao { get; set; }
    public DateTime Hora { get; set; }
    public string DonoLoja { get; set; }
    public string NomeLoja { get; set; }
}

