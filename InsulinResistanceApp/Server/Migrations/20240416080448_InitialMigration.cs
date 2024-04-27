using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsulinResistanceApp.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashowaneHaslo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Sol = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DataUtworzeniaKonta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    resetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resetTokenNiewazny = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kcal = table.Column<int>(type: "int", nullable: false),
                    weglowodany = table.Column<int>(type: "int", nullable: false),
                    tluszcze = table.Column<int>(type: "int", nullable: false),
                    bialko = table.Column<int>(type: "int", nullable: false),
                    indeksglikemiczny = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkty_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Owoce" },
                    { 2, "Warzywa" },
                    { 3, "Nabiał" },
                    { 4, "Mięso" },
                    { 5, "Ryby" },
                    { 6, "Produkty zbożowe" },
                    { 7, "Słodycze" },
                    { 8, "Napoje" },
                    { 9, "Inne" }
                });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "Id", "KategoriaId", "Nazwa", "bialko", "indeksglikemiczny", "kcal", "tluszcze", "weglowodany" },
                values: new object[,]
                {
                    { 1, 1, "Jabłka", 0, 38, 52, 0, 14 },
                    { 2, 1, "Banany", 1, 51, 89, 0, 23 },
                    { 3, 1, "Pomarańcze", 1, 43, 43, 0, 9 },
                    { 4, 1, "Awokado", 2, 10, 160, 15, 9 },
                    { 5, 6, "Chleb pełnoziarnisty", 10, 50, 250, 4, 45 },
                    { 6, 9, "Masło orzechowe", 25, 30, 588, 50, 20 },
                    { 7, 3, "Jogurt naturalny", 10, 36, 61, 3, 4 },
                    { 8, 3, "Mleko 2%", 3, 30, 50, 2, 5 },
                    { 9, 3, "Twaróg", 18, 45, 174, 9, 3 },
                    { 10, 4, "Kurczak", 27, 0, 239, 14, 0 },
                    { 11, 5, "Łosoś", 20, 0, 208, 13, 0 },
                    { 12, 3, "Jajko", 6, 0, 68, 5, 1 },
                    { 13, 6, "Ryż brązowy", 2, 50, 111, 1, 23 },
                    { 14, 6, "Makaron pełnoziarnisty", 7, 40, 158, 1, 31 },
                    { 15, 9, "Oliwa z oliwek", 0, 0, 884, 100, 0 },
                    { 16, 9, "Orzechy włoskie", 16, 15, 654, 65, 14 },
                    { 17, 6, "Kasza jaglana", 8, 40, 346, 1, 77 },
                    { 18, 6, "Owies", 17, 50, 389, 7, 66 },
                    { 19, 7, "Czekolada gorzka", 5, 22, 546, 32, 31 },
                    { 20, 2, "Czosnek", 6, 30, 149, 0, 33 },
                    { 21, 2, "Cebula", 1, 10, 40, 0, 9 },
                    { 22, 2, "Brokuły", 3, 10, 34, 0, 7 },
                    { 23, 2, "Papryka czerwona", 1, 10, 31, 0, 7 },
                    { 24, 2, "Pomidor", 1, 10, 18, 0, 4 },
                    { 25, 9, "Tymianek", 9, 15, 276, 7, 64 },
                    { 26, 9, "Sól", 0, 0, 0, 0, 0 },
                    { 27, 9, "Pieprz", 10, 15, 251, 3, 64 },
                    { 28, 9, "Kurkuma", 8, 0, 354, 10, 65 },
                    { 29, 2, "Chili", 2, 10, 40, 0, 9 },
                    { 30, 8, "Kawa", 0, 0, 1, 0, 0 },
                    { 31, 8, "Herbata", 0, 0, 1, 0, 0 },
                    { 32, 7, "Miod", 0, 50, 304, 0, 82 },
                    { 33, 1, "Cytryna", 1, 20, 29, 0, 9 },
                    { 34, 1, "Liczi", 0, 50, 66, 0, 16 },
                    { 35, 1, "Winogrona", 1, 59, 69, 0, 18 },
                    { 36, 1, "Truskawki", 1, 25, 32, 0, 8 },
                    { 37, 9, "Pizza Margherita", 12, 30, 266, 9, 32 },
                    { 38, 2, "Sałatka grecka", 7, 15, 159, 10, 11 },
                    { 39, 7, "Czekolada mleczna", 8, 40, 535, 30, 58 },
                    { 40, 4, "Burger wołowy", 12, 30, 254, 14, 28 },
                    { 41, 4, "Kanapka z szynką", 12, 30, 210, 8, 23 },
                    { 42, 6, "Owsianka z miodem", 6, 40, 230, 4, 50 }
                });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "Id", "KategoriaId", "Nazwa", "bialko", "indeksglikemiczny", "kcal", "tluszcze", "weglowodany" },
                values: new object[,]
                {
                    { 43, 4, "Kiełbasa", 15, 0, 331, 30, 2 },
                    { 44, 7, "Lody waniliowe", 3, 40, 207, 11, 25 },
                    { 45, 7, "Chipsy ziemniaczane", 6, 75, 536, 34, 50 },
                    { 46, 8, "Herbata z cukrem", 0, 65, 43, 0, 11 },
                    { 47, 8, "Kawa z mlekiem i cukrem", 1, 45, 43, 1, 7 },
                    { 48, 8, "Coca-Cola", 0, 63, 42, 0, 11 },
                    { 49, 2, "Sałatka owocowa z majonezem", 3, 40, 210, 5, 45 },
                    { 50, 7, "Ciastka czekoladowe", 5, 50, 480, 22, 63 },
                    { 51, 7, "Orzechy nerkowca", 18, 20, 553, 44, 30 },
                    { 52, 7, "Lody czekoladowe", 3, 40, 216, 12, 28 },
                    { 53, 3, "Jogurt owocowy", 4, 35, 85, 2, 15 },
                    { 54, 4, "Kurczak pieczony", 31, 0, 165, 3, 0 },
                    { 55, 5, "Makaron biały", 5, 50, 158, 1, 31 },
                    { 56, 7, "Chipsy kukurydziane", 6, 85, 536, 35, 51 },
                    { 57, 8, "Sok pomarańczowy", 1, 40, 45, 0, 11 },
                    { 58, 7, "Pączek", 4, 70, 280, 16, 31 },
                    { 59, 7, "Czekolada gorzka 70%", 7, 30, 581, 42, 45 },
                    { 60, 5, "Ryż biały", 3, 70, 130, 0, 28 },
                    { 61, 3, "Ser żółty", 25, 0, 402, 33, 2 },
                    { 62, 8, "Piwo", 1, 55, 43, 0, 3 },
                    { 63, 8, "Wódka", 0, 0, 231, 0, 0 },
                    { 64, 2, "Szpinak", 2, 15, 23, 0, 3 },
                    { 65, 4, "Mleko kozie", 3, 30, 68, 5, 4 },
                    { 66, 9, "Olej rzepakowy", 0, 0, 884, 100, 0 },
                    { 67, 4, "Mleko sojowe", 3, 20, 33, 1, 1 },
                    { 68, 4, "Tofu", 8, 15, 76, 4, 1 },
                    { 69, 5, "Quinoa", 4, 53, 120, 2, 21 },
                    { 70, 1, "Jabłka suszone", 2, 38, 243, 0, 63 },
                    { 71, 1, "Mango", 1, 51, 60, 0, 15 },
                    { 72, 7, "Orzechy laskowe", 15, 15, 628, 61, 20 },
                    { 73, 8, "Kawa z syropem waniliowym", 3, 45, 293, 7, 42 },
                    { 74, 2, "Kiełki lucerny", 4, 10, 23, 0, 4 },
                    { 75, 5, "Kasza gryczana", 13, 50, 335, 3, 70 },
                    { 76, 2, "Kapusta kiszona", 1, 10, 19, 0, 4 },
                    { 77, 8, "Woda gazowana", 0, 0, 0, 0, 0 },
                    { 78, 2, "Mięta", 4, 15, 70, 1, 14 },
                    { 79, 4, "Miód", 0, 50, 304, 0, 82 },
                    { 80, 2, "Kurkuma", 8, 0, 354, 10, 65 },
                    { 81, 4, "Sardynki w oleju", 25, 0, 208, 11, 0 },
                    { 82, 4, "Krewetki", 18, 0, 85, 1, 0 },
                    { 83, 1, "Czarna porzeczka", 1, 25, 56, 0, 14 },
                    { 84, 4, "Sushi z łososiem", 4, 45, 132, 3, 22 }
                });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "Id", "KategoriaId", "Nazwa", "bialko", "indeksglikemiczny", "kcal", "tluszcze", "weglowodany" },
                values: new object[,]
                {
                    { 85, 1, "Awokado", 2, 10, 160, 15, 9 },
                    { 86, 7, "Migdały", 21, 0, 575, 49, 22 },
                    { 87, 8, "Pomarańczowy sok", 1, 45, 45, 0, 11 },
                    { 88, 5, "Granola", 12, 55, 471, 20, 58 },
                    { 89, 4, "Kokosowe mleko", 2, 45, 230, 23, 6 },
                    { 90, 1, "Banany suszone", 3, 65, 346, 1, 87 },
                    { 91, 1, "Grapefruit", 1, 25, 42, 0, 11 },
                    { 92, 2, "Kurkuma w proszku", 9, 0, 312, 3, 68 },
                    { 93, 8, "Herbata zielona", 0, 0, 1, 0, 0 },
                    { 94, 8, "Woda kokosowa", 0, 45, 19, 0, 4 },
                    { 95, 2, "Czosnek", 6, 30, 149, 0, 33 },
                    { 96, 2, "Bób", 27, 20, 341, 1, 63 },
                    { 97, 2, "Pietruszka", 4, 20, 45, 0, 10 },
                    { 98, 3, "Jogurt naturalny", 10, 36, 61, 3, 4 },
                    { 99, 6, "Ryż basmati", 3, 58, 130, 0, 28 },
                    { 100, 3, "Migdałowe mleko", 1, 25, 56, 5, 1 },
                    { 101, 8, "Sok jabłkowy", 0, 40, 46, 0, 12 },
                    { 102, 9, "Tahini", 17, 0, 595, 53, 17 },
                    { 103, 9, "Oliwa z oliwek", 0, 0, 884, 100, 0 },
                    { 104, 1, "Truskawki", 1, 25, 32, 0, 8 },
                    { 105, 1, "Jabłko", 0, 38, 52, 0, 14 },
                    { 106, 1, "Mango", 1, 51, 60, 0, 15 },
                    { 107, 1, "Maliny", 1, 25, 52, 0, 12 },
                    { 108, 1, "Ananas", 0, 66, 50, 0, 13 },
                    { 109, 2, "Ogórek", 1, 10, 15, 0, 3 },
                    { 110, 2, "Marchew", 1, 35, 41, 0, 10 },
                    { 111, 2, "Szpinak", 2, 15, 23, 0, 3 },
                    { 112, 2, "Banan", 1, 51, 89, 0, 23 },
                    { 113, 6, "Kasza jaglana", 8, 40, 346, 1, 77 },
                    { 114, 9, "Orzechy włoskie", 16, 15, 654, 65, 14 },
                    { 115, 4, "Kurczak", 27, 0, 239, 14, 0 },
                    { 116, 5, "Losos", 20, 0, 208, 13, 0 },
                    { 117, 3, "Jajko", 6, 0, 68, 5, 1 },
                    { 118, 7, "Czekolada gorzka", 5, 22, 546, 32, 31 },
                    { 119, 7, "Czekolada mleczna", 8, 40, 535, 30, 58 },
                    { 120, 3, "Mleko", 3, 30, 42, 2, 5 },
                    { 121, 8, "Herbata", 0, 0, 1, 0, 0 },
                    { 122, 8, "Coca-Cola", 0, 63, 42, 0, 11 },
                    { 123, 8, "Kawa", 0, 0, 1, 0, 0 },
                    { 124, 1, "Arbuz", 1, 70, 30, 0, 8 },
                    { 125, 1, "Brzoskwinia", 1, 28, 39, 0, 10 },
                    { 126, 1, "Kiwi", 1, 52, 61, 0, 15 }
                });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "Id", "KategoriaId", "Nazwa", "bialko", "indeksglikemiczny", "kcal", "tluszcze", "weglowodany" },
                values: new object[,]
                {
                    { 127, 1, "Granat", 1, 53, 83, 1, 19 },
                    { 128, 1, "Śliwki", 1, 39, 46, 0, 11 },
                    { 129, 1, "Mandarynki", 1, 47, 53, 0, 13 },
                    { 130, 1, "Czarna porzeczka", 1, 25, 56, 0, 14 },
                    { 131, 1, "Kumkwat", 2, 40, 71, 0, 16 },
                    { 132, 1, "Liczi", 1, 50, 66, 0, 17 },
                    { 133, 1, "Papaja", 1, 59, 43, 0, 11 },
                    { 134, 1, "Czereśnie", 1, 22, 63, 0, 16 },
                    { 135, 1, "Nektarynka", 1, 32, 44, 0, 11 },
                    { 136, 1, "Jeżyny", 1, 25, 43, 1, 10 },
                    { 137, 1, "Granat", 1, 53, 83, 1, 19 },
                    { 138, 2, "Papryka czerwona", 1, 30, 31, 0, 7 },
                    { 139, 1, "Malina", 1, 25, 52, 0, 12 },
                    { 140, 1, "Truskawka", 1, 25, 32, 0, 8 },
                    { 141, 2, "Por", 2, 15, 31, 0, 7 },
                    { 142, 2, "Rzodkiewka", 1, 15, 16, 0, 3 },
                    { 143, 2, "Dynia", 1, 75, 26, 0, 6 },
                    { 144, 2, "Kapusta pekińska", 1, 10, 13, 0, 3 },
                    { 145, 2, "Kalafior", 2, 15, 25, 0, 5 },
                    { 146, 3, "Mleko krowie", 3, 30, 42, 2, 5 },
                    { 147, 3, "Ser biały", 10, 35, 98, 5, 4 },
                    { 148, 3, "Jogurt naturalny", 10, 36, 61, 3, 4 },
                    { 149, 3, "Twaróg", 18, 30, 103, 5, 3 },
                    { 150, 9, "Masło", 1, 0, 717, 81, 0 },
                    { 151, 4, "Kurczak", 27, 0, 239, 14, 0 },
                    { 152, 4, "Wołowina", 28, 0, 250, 16, 0 },
                    { 153, 5, "Śledź", 18, 0, 203, 14, 0 },
                    { 154, 4, "Szynka", 15, 0, 101, 4, 1 },
                    { 155, 4, "Indyk", 30, 0, 135, 3, 0 },
                    { 156, 4, "Kiełbasa", 14, 0, 325, 29, 2 },
                    { 157, 4, "Boczek", 9, 0, 458, 45, 0 },
                    { 158, 3, "Żółtko jajka", 17, 0, 322, 27, 1 },
                    { 159, 4, "Wieprzowina", 21, 0, 242, 17, 0 },
                    { 160, 4, "Kaczka", 24, 0, 337, 27, 0 },
                    { 161, 4, "Cielęcina", 21, 0, 111, 3, 0 },
                    { 162, 4, "Baranina", 22, 0, 294, 23, 0 },
                    { 163, 4, "Kurczak", 27, 0, 239, 14, 0 },
                    { 164, 4, "Indyk", 30, 0, 135, 3, 0 },
                    { 165, 3, "Jajko", 6, 0, 68, 5, 1 },
                    { 166, 5, "Tunczyk", 26, 0, 116, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_KategoriaId",
                table: "Produkty",
                column: "KategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
