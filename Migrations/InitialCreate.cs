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
                    Nome = Table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sobrenome = Table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CPF = Table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IsActive = Table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Username = Table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnderecoId = Table.Column<int>(type: "int", nullable: false),
                    Email = Table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = Table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NivelAcesso = Table.Column<int>(type: "int", nullable: false),
                    Senha = Table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
            migrationBuilder.CreateTable(
                name: "Artigo",
                    columns: Table => new
                    {
                        ArtigoID = Table.Column<int>(type: "int", nullable: false),
                        Titulo = Table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                        SubTitulo = Table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                        TopicoID = Table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Artigo", x => x.ArtigoID).Annotation("SqlServer:Clustered", true);
                        table.ForeignKey(
                            name: "FK_Artigo_Topicos",
                            column: x => x.TopicoID,
                            principalTable: "Topicos",
                            principalColumn: "TopicoID",
                            onDelete: ReferentialAction.SetNull);
                    });
            migrationBuilder.CreateTable(
                name: "Topico",
                    columns: Table => new
                    {
                        TopicoID = Table.Column<int>(type: "int", nullable: false),
                        Titulo = Table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                        SubTitulo = Table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Topico", x => x.TopicoID).Annotation("SqlServer:Clustered", true);
                    });
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Enderecos_EstadosBrasileiros",
                        column: x => x.EstadosId,
                        principalTable: "EstadosBrasileiros",
                        principalColumn: "EstadosBrasileirosId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "LogAlteracoes",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabela = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistroID = table.Column<int>(type: "int", nullable: false),
                    CampoAlterado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorAntigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorNovo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAlteracoes", x => x.LogID)
                        .Annotation("SqlServer:Clustered", true);

                    table.ForeignKey(
                        name: "FK_LogAlteracoes_Usuarios",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogAlteracoes_UsuarioID",
                table: "LogAlteracoes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_UsuarioID",
                table: "Denuncia",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_EnderecoId",
                table: "Denuncia",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosBrasileiros_UF",
                table: "EstadosBrasileiros",
                column: "UF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstadosId",
                table: "Enderecos",
                column: "EstadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CEP",
                table: "Enderecos",
                column: "CEP");

            migrationBuilder.CreateIndex(
                name: "IX_Artigo_TopicoID",
                table: "Artigo",
                column: "TopicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Topico_Titulo",
                table: "Topico",
                column: "Titulo");
        }
    }
}

