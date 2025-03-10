using System;
using BlogNatureDB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogNatureDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: Table => new
                {
                    UserId = Table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = Table.Column<string>(type: "nvarchar(30)", maxLength: 80, nullable: false),
                    Sobrenome = Table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CPF = Table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IsActive = Table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Username = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false),
                    Email = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false),
                    Telefone = Table.Column<string>(type: "nvarchar(20)", maxLength: 80, nullable: false),
                    NivelAcesso = Table.Column<int>(type: "int", nullable: false),
                    Senha = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false)
                }
        }
    }
}
