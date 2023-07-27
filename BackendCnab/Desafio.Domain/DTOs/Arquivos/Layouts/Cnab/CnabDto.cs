using Desafio.Domain.Enums;
using System;

namespace Desafio.Domain.DTOs.Arquivos.Layouts.Cnab;

public class CnabDto
{
    public int Tipo { get; set; }
    public string TipoDescricao => EnumHelper.GetDescription((ETipo)Tipo);
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public string Cpf { get; set; }
    public string Cartao { get; set; }
    public DateTime Hora { get; set; }
    public string DonoLoja { get; set; }
    public string NomeLoja { get; set; }
}

