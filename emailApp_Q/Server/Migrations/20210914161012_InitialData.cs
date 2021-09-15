using Microsoft.EntityFrameworkCore.Migrations;

namespace emailApp_Q.Server.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Importances",
                columns: new[] { "ImportanceId", "Name" },
                values: new object[] { 1, "Low" });

            migrationBuilder.InsertData(
                table: "Importances",
                columns: new[] { "ImportanceId", "Name" },
                values: new object[] { 2, "Normal" });

            migrationBuilder.InsertData(
                table: "Importances",
                columns: new[] { "ImportanceId", "Name" },
                values: new object[] { 3, "High" });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "MailId", "CC", "Content", "ImportanceId", "Reciver", "Sender", "Subject" },
                values: new object[] { 1, "", "Dummy text for test", 1, "dunja.korak@q.agency", "mbelancic9@gmail.com", "Test mail" });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "MailId", "CC", "Content", "ImportanceId", "Reciver", "Sender", "Subject" },
                values: new object[] { 2, "someone@gmail.com, someone_else@q.agency", "Dummy text for test received successfully", 3, "mbelancic9@gmail.com", "dunja.korak@q.agency", "Received  dummy e-mail" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Importances",
                keyColumn: "ImportanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "MailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "MailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Importances",
                keyColumn: "ImportanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Importances",
                keyColumn: "ImportanceId",
                keyValue: 3);
        }
    }
}
