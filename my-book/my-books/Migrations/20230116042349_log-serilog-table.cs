﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mybooks.Migrations
{
    /// <inheritdoc />
    public partial class logserilogtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "varchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "varchar(max)", nullable: true),
                    Level = table.Column<string>(type: "varchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Properties = table.Column<string>(type: "varchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "varchar(max)", nullable: true),
                    LogEvent = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
