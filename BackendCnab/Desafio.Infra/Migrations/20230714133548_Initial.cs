﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(nullable: false),
                    tipo = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(nullable: false),
                    cpf = table.Column<string>(nullable: false),
                    cartao = table.Column<string>(nullable: false),
                    hora = table.Column<DateTime>(nullable: false),
                    dono_loja = table.Column<string>(nullable: false),
                    nome_loja = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
