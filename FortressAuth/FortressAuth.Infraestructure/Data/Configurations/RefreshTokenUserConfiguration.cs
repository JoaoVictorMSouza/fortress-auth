using FortressAuth.Domain.Entities;
using FortressAuth.Infraestructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortressAuth.Infraestructure.Data.Configurations
{
    internal class RefreshTokenUserConfiguration : EntityTypeConfigurationGuid<RefreshTokenUser>
    {
        public RefreshTokenUserConfiguration() : base("TB_REFRESH_TOKEN_USER")
        {
            
        }

        public override void OnConfigure(EntityTypeBuilder<RefreshTokenUser> builder)
        {
            builder.Property(x => x.Token)
                .HasColumnName("DS_TOKEN")
                .IsRequired();
            builder.HasIndex(x => x.Token).IsUnique();

            builder.Property(x => x.ExpiresAtUtc)
                .HasColumnName("DH_EXPIRES_AT_UTC")
                .IsRequired();

            builder.Property(x => x.Revoked)
                .HasConversion<int>()
                .HasColumnName("TG_REVOKED");
        }
    }
}
