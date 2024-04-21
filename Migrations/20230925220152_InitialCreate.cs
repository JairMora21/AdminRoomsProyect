using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminRooms.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    Id_Casa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Numero_Cuartos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.Id_Casa);
                });

            migrationBuilder.CreateTable(
                name: "CuartoViewModel",
                columns: table => new
                {
                    IdCuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHuesped = table.Column<int>(type: "int", nullable: true),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuartoViewModel", x => x.IdCuarto);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id_Gasto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Gasto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id_Gasto);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id_Genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id_Genero);
                });

            migrationBuilder.CreateTable(
                name: "HuespedViewModel",
                columns: table => new
                {
                    IdHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    MotivoEstancia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoInicial = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuespedViewModel", x => x.IdHuesped);
                });

            migrationBuilder.CreateTable(
                name: "GastosRegistro",
                columns: table => new
                {
                    Id_GastosRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Gastos = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosRegistro", x => x.Id_GastosRegistro);
                    table.ForeignKey(
                        name: "FK_GastosRegistro_Gastos",
                        column: x => x.Id_Gastos,
                        principalTable: "Gastos",
                        principalColumn: "Id_Gasto");
                });

            migrationBuilder.CreateTable(
                name: "Asignacion",
                columns: table => new
                {
                    Id_Asignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cuarto = table.Column<int>(type: "int", nullable: false),
                    Id_Casa = table.Column<int>(type: "int", nullable: false),
                    Id_Huesped = table.Column<int>(type: "int", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Salida_Prev = table.Column<DateTime>(type: "date", nullable: true),
                    Fecha_Pago = table.Column<DateTime>(type: "date", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion", x => x.Id_Asignacion);
                    table.ForeignKey(
                        name: "FK_Asignacion_Casa",
                        column: x => x.Id_Casa,
                        principalTable: "Casa",
                        principalColumn: "Id_Casa");
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    Id_Cobros = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Asignacion = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<DateTime>(type: "date", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.Id_Cobros);
                    table.ForeignKey(
                        name: "FK_Cobros_Asignacion",
                        column: x => x.Id_Asignacion,
                        principalTable: "Asignacion",
                        principalColumn: "Id_Asignacion");
                });

            migrationBuilder.CreateTable(
                name: "Cuarto",
                columns: table => new
                {
                    Id_Cuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Huesped = table.Column<int>(type: "int", nullable: true),
                    Id_Casa = table.Column<int>(type: "int", nullable: true),
                    Numero_Cuarto = table.Column<int>(type: "int", nullable: true),
                    Costo = table.Column<double>(type: "float", nullable: true),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuarto", x => x.Id_Cuarto);
                    table.ForeignKey(
                        name: "FK_Cuarto_Casa",
                        column: x => x.Id_Casa,
                        principalTable: "Casa",
                        principalColumn: "Id_Casa");
                });

            migrationBuilder.CreateTable(
                name: "Huesped",
                columns: table => new
                {
                    Id_Huesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Casa = table.Column<int>(type: "int", nullable: true),
                    Id_Cuarto = table.Column<int>(type: "int", nullable: true),
                    Id_Genero = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Motivo_Estancia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Telefono_Emergencia = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Correo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Pago_Inicial = table.Column<double>(type: "float", nullable: true),
                    Fecha_Alta = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.Id_Huesped);
                    table.ForeignKey(
                        name: "FK_Huesped_Casa",
                        column: x => x.Id_Casa,
                        principalTable: "Casa",
                        principalColumn: "Id_Casa");
                    table.ForeignKey(
                        name: "FK_Huesped_Cuarto",
                        column: x => x.Id_Cuarto,
                        principalTable: "Cuarto",
                        principalColumn: "Id_Cuarto");
                    table.ForeignKey(
                        name: "FK_Huesped_Genero",
                        column: x => x.Id_Genero,
                        principalTable: "Genero",
                        principalColumn: "Id_Genero");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Id_Casa",
                table: "Asignacion",
                column: "Id_Casa");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Id_Cuarto",
                table: "Asignacion",
                column: "Id_Cuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Id_Huesped",
                table: "Asignacion",
                column: "Id_Huesped");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_Id_Asignacion",
                table: "Cobros",
                column: "Id_Asignacion");

            migrationBuilder.CreateIndex(
                name: "IX_Cuarto_Id_Casa",
                table: "Cuarto",
                column: "Id_Casa");

            migrationBuilder.CreateIndex(
                name: "IX_Cuarto_Id_Huesped",
                table: "Cuarto",
                column: "Id_Huesped");

            migrationBuilder.CreateIndex(
                name: "IX_GastosRegistro_Id_Gastos",
                table: "GastosRegistro",
                column: "Id_Gastos");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Casa",
                table: "Huesped",
                column: "Id_Casa");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Cuarto",
                table: "Huesped",
                column: "Id_Cuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Genero",
                table: "Huesped",
                column: "Id_Genero");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignacion_Cuarto",
                table: "Asignacion",
                column: "Id_Cuarto",
                principalTable: "Cuarto",
                principalColumn: "Id_Cuarto");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignacion_Huesped",
                table: "Asignacion",
                column: "Id_Huesped",
                principalTable: "Huesped",
                principalColumn: "Id_Huesped");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuarto_Huesped",
                table: "Cuarto",
                column: "Id_Huesped",
                principalTable: "Huesped",
                principalColumn: "Id_Huesped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuarto_Casa",
                table: "Cuarto");

            migrationBuilder.DropForeignKey(
                name: "FK_Huesped_Casa",
                table: "Huesped");

            migrationBuilder.DropForeignKey(
                name: "FK_Huesped_Cuarto",
                table: "Huesped");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "CuartoViewModel");

            migrationBuilder.DropTable(
                name: "GastosRegistro");

            migrationBuilder.DropTable(
                name: "HuespedViewModel");

            migrationBuilder.DropTable(
                name: "Asignacion");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Cuarto");

            migrationBuilder.DropTable(
                name: "Huesped");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
