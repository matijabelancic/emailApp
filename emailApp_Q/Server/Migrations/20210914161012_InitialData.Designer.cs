// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emailApp_Q.Server.DataAccess;

namespace emailApp_Q.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210914161012_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("emailApp_Q.Shared.Importance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImportanceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Importances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Low"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "High"
                        });
                });

            modelBuilder.Entity("emailApp_Q.Shared.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MailId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImportanceId")
                        .HasColumnType("int");

                    b.Property<string>("Reciver")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImportanceId");

                    b.ToTable("Mails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CC = "",
                            Content = "Dummy text for test",
                            ImportanceId = 1,
                            Reciver = "dunja.korak@q.agency",
                            Sender = "mbelancic9@gmail.com",
                            Subject = "Test mail"
                        },
                        new
                        {
                            Id = 2,
                            CC = "someone@gmail.com, someone_else@q.agency",
                            Content = "Dummy text for test received successfully",
                            ImportanceId = 3,
                            Reciver = "mbelancic9@gmail.com",
                            Sender = "dunja.korak@q.agency",
                            Subject = "Received  dummy e-mail"
                        });
                });

            modelBuilder.Entity("emailApp_Q.Shared.Mail", b =>
                {
                    b.HasOne("emailApp_Q.Shared.Importance", "Importance")
                        .WithMany()
                        .HasForeignKey("ImportanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Importance");
                });
#pragma warning restore 612, 618
        }
    }
}
