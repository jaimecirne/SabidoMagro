using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SabidoMagroAcademia.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Clients");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Plans",
                type: "float(10)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Start = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    End = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Born = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    CoachsComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliations_Managers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientWorkouts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientWorkouts_Managers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientWorkoutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_ClientWorkouts_ClientWorkoutId",
                        column: x => x.ClientWorkoutId,
                        principalTable: "ClientWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayOfTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOfTrains_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayOfTrains_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayOfTrains_Managers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayOfTrains_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Rest = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutActivity_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Agachamento com barra" },
                    { 55, "Rosca direta com barra" },
                    { 54, "Extensão de perna na máquina" },
                    { 53, "Flexão de perna na máquina" },
                    { 52, "Adição de quadril na máquina" },
                    { 51, "Abdução de quadril na máquina" },
                    { 50, "Elevação posterior" },
                    { 49, "Elevação de panturrilha com halteres" },
                    { 48, "Elevação de panturrilha com barra" },
                    { 47, "Agachamento com salto" },
                    { 46, "Agachamento sumô" },
                    { 45, "Leg Press" },
                    { 44, "Cadeira flexora" },
                    { 43, "Cadeira extensora" },
                    { 42, "Stiff com halteres" },
                    { 41, "Stiff com barra" },
                    { 56, "Rosca direta com halteres" },
                    { 40, "Flexão plantar na máquina" },
                    { 57, "Rosca inversa com barra" },
                    { 59, "Rosca concentrada com halteres" },
                    { 74, "Elevação frontal com barra" },
                    { 73, "Elevação frontal com halteres" },
                    { 72, "Elevação lateral com halteres" },
                    { 71, "Desenvolvimento com halteres" },
                    { 70, "Desenvolvimento com barra" },
                    { 69, "Remada curvada com halteres" },
                    { 68, "Remada curvada com barra" },
                    { 67, "Remada alta com halteres T" },
                    { 66, "Remada alta com barra T" },
                    { 65, "Flexão de antebraço com corda" },
                    { 64, "Flexão de antebraço com halteres" },
                    { 63, "Flexão de antebraço com barra" },
                    { 62, "Tríceps com corda" },
                    { 61, "Tríceps com halteres" },
                    { 60, "Tríceps na barra paralela" },
                    { 58, "Rosca inversa com halteres" },
                    { 39, "Lunge lateral" },
                    { 38, "Lunge com salto" },
                    { 37, "Lunge tradicional" },
                    { 16, "Flexão de braço em plyo" },
                    { 15, "Flexão de braço com as mãos afastadas" },
                    { 14, "Flexão de braço em diamante" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 13, "Flexão de braço tradicional" },
                    { 12, "Remada baixa com halteres" },
                    { 11, "Remada baixa com barra" },
                    { 10, "Remada alta com halteres" },
                    { 9, "Remada alta com barra" },
                    { 8, "Puxada de peso com halteres" },
                    { 7, "Puxada de peso com barra" },
                    { 6, "Levantamento terra com halteres" },
                    { 5, "Levantamento terra com barra" },
                    { 4, "Agachamento isométrico" },
                    { 3, "Agachamento com kettlebell" },
                    { 2, "Agachamento com halteres" },
                    { 17, "Flexão de braço com uma mão" },
                    { 18, "Abdominal tradicional" },
                    { 19, "Abdominal inverso" },
                    { 20, "Abdominal oblíquo" },
                    { 36, "Jump Squats" },
                    { 35, "Jumping Jacks" },
                    { 34, "Step na plataforma" },
                    { 33, "Escalada na máquina de escalada" },
                    { 32, "Remo na máquina de remo" },
                    { 31, "Ciclismo na bicicleta ergométrica" },
                    { 30, "Caminhada na esteira com inclinação" },
                    { 29, "Corrida na esteira" },
                    { 27, "Burpee com flexão de braço" },
                    { 26, "Burpee com elevação de perna" },
                    { 25, "Burpee tradicional" },
                    { 24, "Prancha com rotação do tronco" },
                    { 23, "Prancha com elevação de perna" },
                    { 22, "Prancha lateral" },
                    { 21, "Prancha tradicional" },
                    { 28, "Burpee com salto" }
                });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 1000.0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliations_ClientId",
                table: "Avaliations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliations_CoachId",
                table: "Avaliations",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientWorkouts_ClientId",
                table: "ClientWorkouts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientWorkouts_CoachId",
                table: "ClientWorkouts",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PlanId",
                table: "Contracts",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfTrains_ClientId",
                table: "DayOfTrains",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfTrains_ClientId1",
                table: "DayOfTrains",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfTrains_CoachId",
                table: "DayOfTrains",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfTrains_WorkoutId",
                table: "DayOfTrains",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_RoleId",
                table: "Resources",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_ManagerId",
                table: "Role",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_ClientWorkoutId",
                table: "Workout",
                column: "ClientWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutActivity_ActivityId",
                table: "WorkoutActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutActivity_WorkoutId",
                table: "WorkoutActivity",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_User_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_User_UserId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Avaliations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "DayOfTrains");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "WorkoutActivity");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "ClientWorkouts");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clients",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Clients",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
