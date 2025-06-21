using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppTurismo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    VacationPackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Reservations",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_VacationPackages_VacationPackageId",
                        column: x => x.VacationPackageId,
                        principalTable: "VacationPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationPackageDestinations",
                columns: table => new
                {
                    VacationPackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPackageDestinations", x => new { x.VacationPackageId, x.DestinationId });
                    table.ForeignKey(
                        name: "FK_VacationPackageDestinations_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationPackageDestinations_VacationPackages_VacationPackageId",
                        column: x => x.VacationPackageId,
                        principalTable: "VacationPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "joao.silva@email.com", "João Silva" },
                    { 2, "maria.oliveira@email.com", "Maria Oliveira" },
                    { 3, "carlos.souza@email.com", "Carlos Souza" },
                    { 4, "ana.paula@email.com", "Ana Paula" },
                    { 5, "lucas.pereira@email.com", "Lucas Pereira" },
                    { 6, "fernanda.costa@email.com", "Fernanda Costa" },
                    { 7, "roberto.santos@email.com", "Roberto Santos" },
                    { 8, "juliana.lima@email.com", "Juliana Lima" },
                    { 9, "pedro.alves@email.com", "Pedro Alves" },
                    { 10, "carla.mendes@email.com", "Carla Mendes" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "França", "Paris" },
                    { 2, "Itália", "Roma" },
                    { 3, "Reino Unido", "Londres" },
                    { 4, "Espanha", "Barcelona" },
                    { 5, "Estados Unidos", "Nova York" },
                    { 6, "Estados Unidos", "Los Angeles" },
                    { 7, "Japão", "Tóquio" },
                    { 8, "Austrália", "Sydney" },
                    { 9, "Brasil", "Rio de Janeiro" },
                    { 10, "Argentina", "Buenos Aires" },
                    { 11, "Tailândia", "Bangkok" },
                    { 12, "Emirados Árabes", "Dubai" }
                });

            migrationBuilder.InsertData(
                table: "VacationPackages",
                columns: new[] { "Id", "MaxCapacity", "Price", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 20, 3500.00m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Europa Clássica" },
                    { 2, 15, 4200.00m, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "América do Norte" },
                    { 3, 10, 5000.00m, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ásia Moderna" },
                    { 4, 25, 1800.00m, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brasil Maravilhoso" },
                    { 5, 12, 6500.00m, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oceania Aventura" },
                    { 6, 8, 4800.00m, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oriente Médio Luxo" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookingDate", "ClientId", "DeletedAt", "VacationPackageId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, null, 1 },
                    { 2, new DateTime(2025, 6, 2, 14, 15, 0, 0, DateTimeKind.Unspecified), 2, null, 1 },
                    { 3, new DateTime(2025, 6, 5, 9, 45, 0, 0, DateTimeKind.Unspecified), 3, null, 2 },
                    { 4, new DateTime(2025, 6, 10, 16, 20, 0, 0, DateTimeKind.Unspecified), 4, null, 3 },
                    { 5, new DateTime(2025, 6, 15, 11, 10, 0, 0, DateTimeKind.Unspecified), 5, null, 4 },
                    { 6, new DateTime(2025, 6, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), 6, null, 1 },
                    { 7, new DateTime(2025, 6, 20, 8, 50, 0, 0, DateTimeKind.Unspecified), 7, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookingDate", "ClientId", "DeletedAt", "IsDeleted", "VacationPackageId" },
                values: new object[] { 8, new DateTime(2025, 6, 22, 15, 40, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 6, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), true, 2 });

            migrationBuilder.InsertData(
                table: "VacationPackageDestinations",
                columns: new[] { "DestinationId", "VacationPackageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 3 },
                    { 11, 3 },
                    { 9, 4 },
                    { 8, 5 },
                    { 12, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_Name_Country",
                table: "Destinations",
                columns: new[] { "Name", "Country" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingDate",
                table: "Reservations",
                column: "BookingDate");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId_VacationPackageId",
                table: "Reservations",
                columns: new[] { "ClientId", "VacationPackageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IsDeleted",
                table: "Reservations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VacationPackageId",
                table: "Reservations",
                column: "VacationPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPackageDestinations_DestinationId",
                table: "VacationPackageDestinations",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPackages_Price",
                table: "VacationPackages",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPackages_StartDate",
                table: "VacationPackages",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPackages_Title",
                table: "VacationPackages",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "VacationPackageDestinations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "VacationPackages");
        }
    }
}
