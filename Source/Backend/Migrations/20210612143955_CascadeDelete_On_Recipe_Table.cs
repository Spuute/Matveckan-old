using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class CascadeDelete_On_Recipe_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "IngredientName");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "IngredientName",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Ingredients",
                type: "float",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
