using System;
using Desafio.Domain.Entities.Arquivos.Layouts.Cnab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infra.Mapping;

public class ArquivoCnabMapping : IEntityTypeConfiguration<Cnab>
{
    public void Configure(EntityTypeBuilder<Cnab> builder)
    {
        builder.ToTable("Transacoes");
        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Tipo)
            .IsRequired()
            .HasColumnName("tipo");

        builder.Property(x => x.Data)
            .IsRequired()
            .HasColumnName("data");

        builder.Property(x => x.Valor)
            .IsRequired()
            .HasColumnName("valor");

        builder.Property(x => x.Cartao)
           .IsRequired()
           .HasColumnName("cartao");

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnName("cpf");


        builder.Property(x => x.Hora)
           .IsRequired()
           .HasColumnName("hora");

        builder.Property(x => x.DonoLoja)
           .IsRequired()
           .HasColumnName("dono_loja");

        builder.Property(x => x.NomeLoja)
           .IsRequired()
           .HasColumnName("nome_loja");
    }
}

