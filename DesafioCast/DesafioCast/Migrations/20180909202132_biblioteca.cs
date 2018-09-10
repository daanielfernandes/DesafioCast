using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DesafioCast.Migrations
{
    public partial class biblioteca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "dbo",
                columns: table => new
                {
                    cd_cliente = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nm_cliente = table.Column<string>(nullable: true),
                    cpf_cliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cd_cliente);
                });

            migrationBuilder.CreateTable(
                name: "livro",
                schema: "dbo",
                columns: table => new
                {
                    cd_livro = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    tt_livro = table.Column<string>(nullable: true),
                    an_livro = table.Column<DateTime>(nullable: false),
                    st_livro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.cd_livro);
                });

            migrationBuilder.CreateTable(
                name: "emprestimo",
                schema: "dbo",
                columns: table => new
                {
                    cd_emprestimo = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dt_emprestimo = table.Column<DateTime>(nullable: false),
                    dt_devolucao = table.Column<DateTime>(nullable: false),
                    cd_livro = table.Column<int>(nullable: false),
                    cd_cliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimo", x => x.cd_emprestimo);
                    table.ForeignKey(
                        name: "FK_emprestimo_cliente_cd_cliente",
                        column: x => x.cd_cliente,
                        principalSchema: "dbo",
                        principalTable: "cliente",
                        principalColumn: "cd_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimo_livro_cd_livro",
                        column: x => x.cd_livro,
                        principalSchema: "dbo",
                        principalTable: "livro",
                        principalColumn: "cd_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_cd_cliente",
                schema: "dbo",
                table: "emprestimo",
                column: "cd_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_cd_livro",
                schema: "dbo",
                table: "emprestimo",
                column: "cd_livro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "livro",
                schema: "dbo");
        }
    }
}
