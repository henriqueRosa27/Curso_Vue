using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_School_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    sobrenome = table.Column<string>(nullable: true),
                    dataNasc = table.Column<string>(nullable: true),
                    idProfessor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_idProfessor",
                        column: x => x.idProfessor,
                        principalTable: "Professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "nome" },
                values: new object[] { 1, "Henrique" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "nome" },
                values: new object[] { 2, "Paula" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "nome" },
                values: new object[] { 3, "Luna" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "dataNasc", "idProfessor", "nome", "sobrenome" },
                values: new object[] { 1, "01/01/2000", 1, "Maria", "José" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "dataNasc", "idProfessor", "nome", "sobrenome" },
                values: new object[] { 2, "20/01/1990", 2, "João", "Paulo" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "dataNasc", "idProfessor", "nome", "sobrenome" },
                values: new object[] { 3, "25/06/1981", 3, "Alex", "Ferraz" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_idProfessor",
                table: "Alunos",
                column: "idProfessor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
