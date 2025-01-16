using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KHRMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Column_Name_For_LeaveType_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "leaveName",
                table: "LeaveType",
                newName: "LeaveName");

            migrationBuilder.RenameColumn(
                name: "leaveType",
                table: "LeaveType",
                newName: "Type");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.RenameColumn(
                name: "LeaveName",
                table: "LeaveType",
                newName: "leaveName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "LeaveType",
                newName: "leaveType");

        }
    }
}
