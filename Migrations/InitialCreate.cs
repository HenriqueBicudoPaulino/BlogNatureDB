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
                    UserID = Table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = Table.Column<string>(type: "nvarchar(30)", maxLength: 80, nullable: false),
                    Sobrenome = Table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CPF = Table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IsActive = Table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Username = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false),
                    EnderecoId = Table.Column<int>(type: "int", nullable: false),
                    Email = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false),
                    Telefone = Table.Column<string>(type: "nvarchar(20)", maxLength: 80, nullable: false),
                    NivelAcesso = Table.Column<int>(type: "int", nullable: false),
                    Senha = Table.Column<string>(type: "nvarchar(50)", maxLength: 80, nullable: false)
                },
                constraints: Table => 
                {
                    Table.PrimaryKey("PK_Usuarios", x => x.UserID).Annotation("SqlServer:Clustered", true);
                    Table.ForeignKey(
                    name: "FK_Enderecos_EnderecoId",
                    column: x => x.EnderecoId,
                    principalTable: "Enderecos",
                    principalColumn: "EnderecoId",
                    onDelete: ReferentialAction.Restrict); 
                });
            migrationBuilder.CreateTable(
                name: "EstadosBrasileiros",
                    columns: table => new
                    {
                        EstadosBrasileirosId = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                        UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                        Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_EstadosBrasileiros", x => x.EstadosBrasileirosId).Annotation("SqlServer:Clustered", true);
                    });

            migrationBuilder.CreateTable(
                name: "Denuncia",
                    columns: Table => new
                    {
                        DenunciaID = Table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                        UsuarioID = Table.Column<int>(type: "int", nullable: true),
                        IsActive = Table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                        Descricao = Table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                        Categoria = Table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                        EnderecoId = Table.Column<int>(type: "int", nullable: false),
                        Responsavel = Table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                        Impactos = Table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                        Arquivo = Table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                        Data = Table.Column<DateTime>(type: "datetime2", nullable: false),
                        Anonimato = Table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Denuncia", x => x.DenunciaID).Annotation("SqlServer:Clustered", true);
                        table.ForeignKey(
                            name: "FK_Denuncia_Endereco",
                            column: x => x.EnderecoId,
                            principalTable: "Enderecos",
                            principalColumn: "EnderecoId",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            name: "FK_Denuncia_Usuarios",
                            column: x => x.UsuarioID,
                            principalTable: "Usuarios",
                            principalColumn: "UsuarioID",
                            onDelete: ReferentialAction.SetNull);
                    });
        }

    }
}

