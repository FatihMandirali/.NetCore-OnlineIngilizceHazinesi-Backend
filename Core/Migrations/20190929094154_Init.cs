using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IstekveSikayet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IstekSikayet = table.Column<string>(nullable: false),
                    KullaniciAdi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstekveSikayet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciAdi = table.Column<string>(nullable: false),
                    isOKey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kelimeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kelime = table.Column<string>(nullable: false),
                    KelimeAnlami = table.Column<string>(nullable: false),
                    KullanicilarId = table.Column<int>(nullable: false),
                    isOKey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelimeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kelimeler_Kullanicilar_KullanicilarId",
                        column: x => x.KullanicilarId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kelimeler_KullanicilarId",
                table: "Kelimeler",
                column: "KullanicilarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IstekveSikayet");

            migrationBuilder.DropTable(
                name: "Kelimeler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
