using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocaCar.Api.Migrations
{
    /// <inheritdoc />
    public partial class MigraçãoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "anos",
                columns: table => new
                {
                    id_ano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_ano = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_ano = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_update_amd = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anos", x => x.id_ano);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carros",
                columns: table => new
                {
                    id_car = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    marca_car = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modelo_car = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ano_car = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cor_car = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipoCorpo_car = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    motor_car = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transmissao_car = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quilometragem_car = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    preco_car = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    numeroPortas_car = table.Column<int>(type: "int", nullable: false),
                    capacidadePassageiros_car = table.Column<int>(type: "int", nullable: false),
                    descricao_car = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_update_amd = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carros", x => x.id_car);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    id_mar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_mar = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_mar = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_update_amd = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.id_mar);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    id_mod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_mod = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_mod = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idMarca_mod = table.Column<int>(type: "int", nullable: false),
                    last_update_amd = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.id_mod);
                    table.ForeignKey(
                        name: "FK_modelos_marcas_idMarca_mod",
                        column: x => x.idMarca_mod,
                        principalTable: "marcas",
                        principalColumn: "id_mar",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "anos_modelos",
                columns: table => new
                {
                    idAno_amd = table.Column<int>(type: "int", nullable: false),
                    idModelo_amd = table.Column<int>(type: "int", nullable: false),
                    last_update_amd = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anos_modelos", x => new { x.idAno_amd, x.idModelo_amd });
                    table.ForeignKey(
                        name: "FK_anos_modelos_anos_idAno_amd",
                        column: x => x.idAno_amd,
                        principalTable: "anos",
                        principalColumn: "id_ano",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_anos_modelos_modelos_idModelo_amd",
                        column: x => x.idModelo_amd,
                        principalTable: "modelos",
                        principalColumn: "id_mod",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_anos_modelos_idModelo_amd",
                table: "anos_modelos",
                column: "idModelo_amd");

            migrationBuilder.CreateIndex(
                name: "IX_modelos_idMarca_mod",
                table: "modelos",
                column: "idMarca_mod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anos_modelos");

            migrationBuilder.DropTable(
                name: "carros");

            migrationBuilder.DropTable(
                name: "anos");

            migrationBuilder.DropTable(
                name: "modelos");

            migrationBuilder.DropTable(
                name: "marcas");
        }
    }
}
