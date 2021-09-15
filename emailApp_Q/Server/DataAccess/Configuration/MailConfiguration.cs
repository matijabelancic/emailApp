using emailApp_Q.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace emailApp_Q.Server.DataAccess.Configuration
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {

        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasData(

                new Mail
                {
                    Id = 1,
                    Sender = "mbelancic9@gmail.com",
                    Reciver = "dunja.korak@q.agency",
                    CC = String.Empty,
                    Subject = "Test mail",
                    ImportanceId = 1,
                    Content = "Dummy text for test"
                },

                new Mail
                {
                    Id = 2,
                    Sender = "dunja.korak@q.agency",
                    Reciver = "mbelancic9@gmail.com",
                    CC = "someone@gmail.com, someone_else@q.agency",
                    Subject = "Received  dummy e-mail",
                    ImportanceId = 3,
                    Content = "Dummy text for test received successfully"
                });
        }
    }
}
