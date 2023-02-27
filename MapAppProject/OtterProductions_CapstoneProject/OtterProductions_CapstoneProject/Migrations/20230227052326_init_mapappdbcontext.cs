using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtterProductionsCapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class initmapappdbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventTyp__3214EC27C715A1DA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MapAppUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspnetIdentityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MapAppUs__3214EC27085551E5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organzation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspnetIdentityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Organzat__3214EC27E4991DB4", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganzationID = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventTypeID = table.Column<int>(type: "int", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__3214EC2726B95BDA", x => x.ID);
                    table.ForeignKey(
                        name: "Fk EventType ID",
                        column: x => x.OrganzationID,
                        principalTable: "EventType",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "Fk Organzation ID",
                        column: x => x.OrganzationID,
                        principalTable: "Organzation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserEventList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapAppUserID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserEven__3214EC27DEE07ADF", x => x.ID);
                    table.ForeignKey(
                        name: "Fk Event ID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "Fk MapAppUser ID",
                        column: x => x.MapAppUserID,
                        principalTable: "MapAppUser",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganzationID",
                table: "Event",
                column: "OrganzationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventList_EventID",
                table: "UserEventList",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventList_MapAppUserID",
                table: "UserEventList",
                column: "MapAppUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventList");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "MapAppUser");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Organzation");
        }
    }
}
