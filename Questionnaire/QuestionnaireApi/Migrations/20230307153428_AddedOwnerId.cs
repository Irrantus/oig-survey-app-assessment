﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionnaireApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Questionnaires",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Questionnaires");
        }
    }
}
