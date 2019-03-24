using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIASA.EOCS.PhotoMicroService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DirectionTypeId = table.Column<int>(nullable: false),
                    LandCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DirectionTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Photo Taken towards North", "North" },
                    { 2, "Photo Taken towards South", "South" },
                    { 3, "Photo Taken towards East", "East" },
                    { 4, "Photo Taken towards West", "West" },
                    { 5, "Photo Taken towards Ground", "Ground" }
                });

            migrationBuilder.InsertData(
                table: "LandCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Land with house and Aprtments", "Residential" },
                    { 2, "Cinema, Museums,Airport etc...", "Amenities" },
                    { 3, "Parks, Stadiumms etc..", "Recreation,Sport" },
                    { 4, "Shops, Supermarkets etc...", "Commerce" },
                    { 5, "Building or developement going on.", "Construction" },
                    { 6, "Crops or other fileds.", "Agriculture" },
                    { 7, "Forest land.", "Forestry" },
                    { 8, "Factory or Manufacturing Plants.", "Insdustry" },
                    { 9, "Road, streets or Rail.", "Transport" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectionTypes");

            migrationBuilder.DropTable(
                name: "LandCategories");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
