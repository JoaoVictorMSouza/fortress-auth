using FortressAuth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortressAuth.Infraestructure.Data.Configurations.Base
{
    internal abstract class EntityTypeConfiguration<TypeId, TEntity> : EntityTypeConfigurationNoKey<TEntity>
        where TEntity : DefaultEntity<TypeId>
    {
        public EntityTypeConfiguration(string tableName) : base(tableName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").IsRequired();

            base.Configure(builder);
        }
    }
}
