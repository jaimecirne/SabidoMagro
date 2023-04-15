using Microsoft.EntityFrameworkCore.Migrations;

namespace SabidoMagroAcademia.Infra.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfTrains_Workout_WorkoutId",
                table: "DayOfTrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_ClientWorkouts_ClientWorkoutId",
                table: "Workout");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutActivity_Activities_ActivityId",
                table: "WorkoutActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutActivity_Workout_WorkoutId",
                table: "WorkoutActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workout",
                table: "Workout");

            migrationBuilder.RenameTable(
                name: "Workout",
                newName: "Workouts");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_ClientWorkoutId",
                table: "Workouts",
                newName: "IX_Workouts_ClientWorkoutId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "WorkoutActivity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "WorkoutActivity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "ClientWorkoutId", "Label" },
                values: new object[] { 1, null, "Treino para Parte Anterior da Perna" });

            migrationBuilder.InsertData(
                table: "WorkoutActivity",
                columns: new[] { "Id", "ActivityId", "Order", "Reps", "Rest", "Sets", "WorkoutId" },
                values: new object[] { 1, 45, 1, 10, 1, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ResourceId",
                table: "Clients",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RoleId",
                table: "Clients",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_WorkoutId",
                table: "Clients",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Resources_ResourceId",
                table: "Clients",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Role_RoleId",
                table: "Clients",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Workouts_WorkoutId",
                table: "Clients",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfTrains_Workouts_WorkoutId",
                table: "DayOfTrains",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutActivity_Activities_ActivityId",
                table: "WorkoutActivity",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutActivity_Workouts_WorkoutId",
                table: "WorkoutActivity",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_ClientWorkouts_ClientWorkoutId",
                table: "Workouts",
                column: "ClientWorkoutId",
                principalTable: "ClientWorkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Resources_ResourceId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Role_RoleId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Workouts_WorkoutId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfTrains_Workouts_WorkoutId",
                table: "DayOfTrains");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutActivity_Activities_ActivityId",
                table: "WorkoutActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutActivity_Workouts_WorkoutId",
                table: "WorkoutActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_ClientWorkouts_ClientWorkoutId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ResourceId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_RoleId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_WorkoutId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.DeleteData(
                table: "WorkoutActivity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "Workout");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_ClientWorkoutId",
                table: "Workout",
                newName: "IX_Workout_ClientWorkoutId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "WorkoutActivity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "WorkoutActivity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workout",
                table: "Workout",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfTrains_Workout_WorkoutId",
                table: "DayOfTrains",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_ClientWorkouts_ClientWorkoutId",
                table: "Workout",
                column: "ClientWorkoutId",
                principalTable: "ClientWorkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutActivity_Activities_ActivityId",
                table: "WorkoutActivity",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutActivity_Workout_WorkoutId",
                table: "WorkoutActivity",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
