using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edux_Api_EFcore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Permissao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objetivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objetivos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    IdInstituicao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Instituicoes_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimoAcesso = table.Column<DateTime>(nullable: false),
                    IdPerfil = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfis_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdCurso = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    UrlImagem = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dicas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosTurmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessoresTurmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoresTurmas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdDica = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curtidas_Dicas_IdDica",
                        column: x => x.IdDica,
                        principalTable: "Dicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curtidas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                        // onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nota = table.Column<decimal>(nullable: false),
                    DataAlcancado = table.Column<DateTime>(nullable: false),
                    IdAlunoTurma = table.Column<Guid>(nullable: false),
                    IdObjetivo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_AlunosTurmas_IdAlunoTurma",
                        column: x => x.IdAlunoTurma,
                        principalTable: "AlunosTurmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_Objetivos_IdObjetivo",
                        column: x => x.IdObjetivo,
                        principalTable: "Objetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdTurma",
                table: "AlunosTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdUsuario",
                table: "AlunosTurmas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdInstituicao",
                table: "Cursos",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdDica",
                table: "Curtidas",
                column: "IdDica");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdUsuario",
                table: "Curtidas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dicas_IdUsuario",
                table: "Dicas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivos_IdCategoria",
                table: "Objetivos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdAlunoTurma",
                table: "ObjetivosAlunos",
                column: "IdAlunoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdObjetivo",
                table: "ObjetivosAlunos",
                column: "IdObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresTurmas_IdTurma",
                table: "ProfessoresTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresTurmas_IdUsuario",
                table: "ProfessoresTurmas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdCurso",
                table: "Turmas",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "ObjetivosAlunos");

            migrationBuilder.DropTable(
                name: "ProfessoresTurmas");

            migrationBuilder.DropTable(
                name: "Dicas");

            migrationBuilder.DropTable(
                name: "AlunosTurmas");

            migrationBuilder.DropTable(
                name: "Objetivos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Instituicoes");
        }
    }
}
