using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Relation_Between_Recipe_And_Instructions_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Instruction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_IngredientId",
                table: "Instruction",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Ingredients_IngredientId",
                table: "Instruction",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Ingredients_IngredientId",
                table: "Instruction");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction");

            migrationBuilder.DropIndex(
                name: "IX_Instruction_IngredientId",
                table: "Instruction");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
