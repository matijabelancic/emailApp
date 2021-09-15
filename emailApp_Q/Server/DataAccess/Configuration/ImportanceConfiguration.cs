using emailApp_Q.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emailApp_Q.Server.DataAccess.Configuration
{
    public class ImportanceConfiguration : IEntityTypeConfiguration<Importance>
    {
        public void Configure(EntityTypeBuilder<Importance> builder)
        {
            builder.HasData(
                new Importance
                {
                    Id = 1,
                    Name = "Low"
                },

               new Importance
               {
                   Id = 2,
                   Name = "Normal"
               },

              new Importance
              {
                  Id = 3,
                  Name = "High"
              });
        }
    }
}
