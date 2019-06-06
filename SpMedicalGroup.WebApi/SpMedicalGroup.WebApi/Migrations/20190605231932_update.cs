using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpMedicalGroup.WebApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLINICAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RAZAO_SOCIAL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    NOME_FANTASIA = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    LOGRADOURO = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    NUMERO = table.Column<int>(nullable: false),
                    BAIRRO = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CIDADE = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ESTADO = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLINICAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CREDENCIAIS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREDENCIAL = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDENCIAIS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESPECIALIDADES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ESPECIALIDADE = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATUS_CONSULTA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SITUACAO = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS_CONSULTA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    SENHA = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ID_CREDENCIAL = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__USUARIOS__ID_CRE__5070F446",
                        column: x => x.ID_CREDENCIAL,
                        principalTable: "CREDENCIAIS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CRM = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: true),
                    ID_ESPECIALIDADE = table.Column<int>(nullable: true),
                    ID_CLINICA = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__MEDICOS__ID_CLIN__5CD6CB2B",
                        column: x => x.ID_CLINICA,
                        principalTable: "CLINICAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MEDICOS__ID_ESPE__5BE2A6F2",
                        column: x => x.ID_ESPECIALIDADE,
                        principalTable: "ESPECIALIDADES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MEDICOS__ID_USUA__5AEE82B9",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    RG = table.Column<string>(unicode: false, maxLength: 9, nullable: false),
                    CPF = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "date", nullable: false),
                    TELEFONE = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    LOGRADOURO = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    NUMERO = table.Column<int>(nullable: false),
                    BAIRRO = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CIDADE = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ESTADO = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PACIENTES__ID_US__5535A963",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(type: "text", nullable: true),
                    DATA_CONSULTA = table.Column<DateTime>(type: "date", nullable: false),
                    HORA_CONSULTA = table.Column<TimeSpan>(nullable: false),
                    ID_PACIENTE = table.Column<int>(nullable: true),
                    ID_MEDICO = table.Column<int>(nullable: true),
                    ID_STATUS = table.Column<int>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CONSULTAS__ID_ME__628FA481",
                        column: x => x.ID_MEDICO,
                        principalTable: "MEDICOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CONSULTAS__ID_PA__619B8048",
                        column: x => x.ID_PACIENTE,
                        principalTable: "PACIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CONSULTAS__ID_ST__6383C8BA",
                        column: x => x.ID_STATUS,
                        principalTable: "STATUS_CONSULTA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__CLINICAS__AA57D6B451AC04ED",
                table: "CLINICAS",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__CLINICAS__10D918D9384F292A",
                table: "CLINICAS",
                column: "RAZAO_SOCIAL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTAS_ID_MEDICO",
                table: "CONSULTAS",
                column: "ID_MEDICO");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTAS_ID_PACIENTE",
                table: "CONSULTAS",
                column: "ID_PACIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTAS_ID_STATUS",
                table: "CONSULTAS",
                column: "ID_STATUS");

            migrationBuilder.CreateIndex(
                name: "UQ__MEDICOS__C1F887FF8B00054C",
                table: "MEDICOS",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MEDICOS_ID_CLINICA",
                table: "MEDICOS",
                column: "ID_CLINICA");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICOS_ID_ESPECIALIDADE",
                table: "MEDICOS",
                column: "ID_ESPECIALIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICOS_ID_USUARIO",
                table: "MEDICOS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "UQ__PACIENTE__C1F89731314B3FB6",
                table: "PACIENTES",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTES_ID_USUARIO",
                table: "PACIENTES",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "UQ__PACIENTE__321537C89E60A7DA",
                table: "PACIENTES",
                column: "RG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__USUARIOS__161CF724B38F03E3",
                table: "USUARIOS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_CREDENCIAL",
                table: "USUARIOS",
                column: "ID_CREDENCIAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTAS");

            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "STATUS_CONSULTA");

            migrationBuilder.DropTable(
                name: "CLINICAS");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADES");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "CREDENCIAIS");
        }
    }
}
