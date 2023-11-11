using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    classid = table.Column<long>(name: "class_id", type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classname = table.Column<string>(name: "class_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classdatetime = table.Column<DateTime>(name: "class_date_time", type: "datetime(6)", nullable: false),
                    maxcapacity = table.Column<int>(name: "max_capacity", type: "int", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.classid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    packageid = table.Column<long>(name: "package_id", type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    packagename = table.Column<string>(name: "package_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    credits = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.packageid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(name: "user_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_classes",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    classid = table.Column<long>(name: "class_id", type: "bigint", nullable: false),
                    bookingdatetime = table.Column<DateTime>(name: "booking_date_time", type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_classes", x => new { x.userid, x.classid });
                    table.ForeignKey(
                        name: "FK_user_classes_classes_class_id",
                        column: x => x.classid,
                        principalTable: "classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_classes_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_packages",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    packageid = table.Column<long>(name: "package_id", type: "bigint", nullable: false),
                    purchasedate = table.Column<DateTime>(name: "purchase_date", type: "datetime(6)", nullable: false),
                    expirydate = table.Column<DateTime>(name: "expiry_date", type: "datetime(6)", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_packages", x => new { x.userid, x.packageid });
                    table.ForeignKey(
                        name: "FK_user_packages_packages_package_id",
                        column: x => x.packageid,
                        principalTable: "packages",
                        principalColumn: "package_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_packages_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastname = table.Column<string>(name: "last_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dob = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profile", x => x.userid);
                    table.ForeignKey(
                        name: "FK_user_profile_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "waitlist",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    classid = table.Column<long>(name: "class_id", type: "bigint", nullable: false),
                    bookingdatetime = table.Column<DateTime>(name: "booking_date_time", type: "datetime(6)", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_waitlist", x => new { x.userid, x.classid });
                    table.ForeignKey(
                        name: "FK_waitlist_classes_class_id",
                        column: x => x.classid,
                        principalTable: "classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_waitlist_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_user_classes_class_id",
                table: "user_classes",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_packages_package_id",
                table: "user_packages",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_waitlist_class_id",
                table: "waitlist",
                column: "class_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_classes");

            migrationBuilder.DropTable(
                name: "user_packages");

            migrationBuilder.DropTable(
                name: "user_profile");

            migrationBuilder.DropTable(
                name: "waitlist");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
