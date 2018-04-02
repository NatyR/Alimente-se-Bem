using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace alimentesebem.sesi.repository.Migrations
{
    public partial class DefaultConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alternativas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    A = table.Column<string>(nullable: false),
                    B = table.Column<string>(nullable: false),
                    C = table.Column<string>(nullable: false),
                    D = table.Column<string>(nullable: false),
                    E = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias_Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Noticias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias_Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(maxLength: 9, nullable: false),
                    Cargo = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Local = table.Column<string>(maxLength: 100, nullable: false),
                    NIF = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Local = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades_Sesi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Unidade = table.Column<string>(maxLength: 10, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Local = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades_Sesi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Criacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 10000, nullable: false),
                    Headline = table.Column<string>(maxLength: 500, nullable: false),
                    Id_Cat_Noticias = table.Column<int>(nullable: false),
                    Imagem = table.Column<string>(nullable: false),
                    Link_Externo = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Categorias_Noticias_Id_Cat_Noticias",
                        column: x => x.Id_Cat_Noticias,
                        principalTable: "Categorias_Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Publicacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 800, nullable: false),
                    Id_Cat_Videos = table.Column<int>(nullable: false),
                    Link_Externo = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    URL = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Categorias_Videos_Id_Cat_Videos",
                        column: x => x.Id_Cat_Videos,
                        principalTable: "Categorias_Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Restaurante = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(maxLength: 50, nullable: false),
                    Serial = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispositivo_Restaurante_Id_Restaurante",
                        column: x => x.Id_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Evento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    Id_Unidade = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(maxLength: 300, nullable: true),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Valor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Unidades_Sesi_Id_Unidade",
                        column: x => x.Id_Unidade,
                        principalTable: "Unidades_Sesi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Fim = table.Column<DateTime>(nullable: false),
                    Data_Inicio = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Id_Alternativa = table.Column<int>(nullable: false),
                    Id_Dispositivo = table.Column<int>(nullable: false),
                    Ordem = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Alternativas_Id_Alternativa",
                        column: x => x.Id_Alternativa,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perguntas_Dispositivo_Id_Dispositivo",
                        column: x => x.Id_Dispositivo,
                        principalTable: "Dispositivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Resposta = table.Column<DateTime>(nullable: false),
                    Id_Pergunta = table.Column<int>(nullable: false),
                    Resposta = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_Id_Pergunta",
                        column: x => x.Id_Pergunta,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Id_Unidade",
                table: "Agenda",
                column: "Id_Unidade");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_Id_Restaurante",
                table: "Dispositivo",
                column: "Id_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_Serial",
                table: "Dispositivo",
                column: "Serial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_Id_Cat_Noticias",
                table: "Noticias",
                column: "Id_Cat_Noticias");

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionista_Email",
                table: "Nutricionista",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionista_NIF",
                table: "Nutricionista",
                column: "NIF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_Id_Alternativa",
                table: "Perguntas",
                column: "Id_Alternativa");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_Id_Dispositivo",
                table: "Perguntas",
                column: "Id_Dispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_Id_Pergunta",
                table: "Respostas",
                column: "Id_Pergunta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_Id_Cat_Videos",
                table: "Videos",
                column: "Id_Cat_Videos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Nutricionista");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Unidades_Sesi");

            migrationBuilder.DropTable(
                name: "Categorias_Noticias");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Categorias_Videos");

            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
