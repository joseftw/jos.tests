using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWeatherApp.Database.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "weather_forecasts",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                date = table.Column<DateOnly>(type: "date", nullable: false),
                temperaturecelsius = table.Column<int>(name: "temperature_celsius", type: "integer", nullable: false),
                summary = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_weather_forecasts", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "weather_forecasts");
    }
}
