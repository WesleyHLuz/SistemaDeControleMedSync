using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeControleMedSync.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
                

            

            

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    ConvenioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConvenioEmpresa",
                columns: table => new
                {
                    ConveniosAceitosId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvenioEmpresa", x => new { x.ConveniosAceitosId, x.EmpresaId });
                    table.ForeignKey(
                        name: "FK_ConvenioEmpresa_Convenios_ConveniosAceitosId",
                        column: x => x.ConveniosAceitosId,
                        principalTable: "Convenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvenioEmpresa_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaConvenios",
                columns: table => new
                {
                    convenioId = table.Column<int>(type: "int", nullable: false),
                    empresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaConvenios", x => new { x.empresaId, x.convenioId });
                    table.ForeignKey(
                        name: "FK_EmpresaConvenios_Convenios_convenioId",
                        column: x => x.convenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaConvenios_Empresas_empresaId",
                        column: x => x.empresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaMedico",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    MedicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaMedico", x => new { x.EmpresaId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_EmpresaMedico_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaMedico_Medicos_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaMedicos",
                columns: table => new
                {
                    medicoId = table.Column<int>(type: "int", nullable: false),
                    empresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaMedicos", x => new { x.medicoId, x.empresaId });
                    table.ForeignKey(
                        name: "FK_EmpresaMedicos_Empresas_empresaId",
                        column: x => x.empresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaMedicos_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadeMedico",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(type: "int", nullable: false),
                    MedicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeMedico", x => new { x.EspecialidadesId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedico_Especialidades_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeMedico_Medicos_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidades",
                columns: table => new
                {
                    medicoId = table.Column<int>(type: "int", nullable: false),
                    especialidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidades", x => new { x.medicoId, x.especialidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Especialidades_especialidadeId",
                        column: x => x.especialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ConvenioId",
                table: "Clientes",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvenioEmpresa_EmpresaId",
                table: "ConvenioEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaConvenios_convenioId",
                table: "EmpresaConvenios",
                column: "convenioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaMedico_MedicosId",
                table: "EmpresaMedico",
                column: "MedicosId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaMedicos_empresaId",
                table: "EmpresaMedicos",
                column: "empresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeMedico_MedicosId",
                table: "EspecialidadeMedico",
                column: "MedicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_EmpresaId",
                table: "Especialidades",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidades_especialidadeId",
                table: "MedicoEspecialidades",
                column: "especialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ClienteId",
                table: "Usuarios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvenioEmpresa");

            migrationBuilder.DropTable(
                name: "EmpresaConvenios");

            migrationBuilder.DropTable(
                name: "EmpresaMedico");

            migrationBuilder.DropTable(
                name: "EmpresaMedicos");

            migrationBuilder.DropTable(
                name: "EspecialidadeMedico");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Convenios");
        }
    }
}
