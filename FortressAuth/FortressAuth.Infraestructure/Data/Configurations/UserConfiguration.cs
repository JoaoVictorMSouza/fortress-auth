using FortressAuth.Domain.Entity;
using FortressAuth.Infraestructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortressAuth.Infraestructure.Data.Configurations
{
    internal class UserConfiguration : EntityTypeConfigurationGuid<User>
    {
        public UserConfiguration(string tableName) : base("TB_USER")
        {

        }

        public override void OnConfigure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Name)
                .HasColumnName("DS_NAME")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("DS_EMAIL")
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("DS_PASSWORD_HASH")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("DS_ROLE")
                .IsRequired();

            builder.Property(x => x.Description);
        }
    }
}
