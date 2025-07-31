using FortressAuth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortressAuth.Infraestructure.Data.Configurations.Base
{
    internal abstract class EntityTypeConfigurationGuid<TEntity> : EntityTypeConfiguration<Guid, TEntity>
        where TEntity : DefaultEntityGuid
    {
        public EntityTypeConfigurationGuid(string tableName) : base(tableName)
        {
        }
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();

            base.Configure(builder);
        }
    }
}
