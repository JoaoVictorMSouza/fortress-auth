using FortressAuth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortressAuth.Infraestructure.Data.Configurations.Base
{
    internal abstract class EntityTypeConfigurationNoKey<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : DefaultEntityNoKey
    {
        private string TableName { get; set; }

        protected EntityTypeConfigurationNoKey(string tableName)
        {
            this.TableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            builder.Property(x => x.IsInactive).HasDefaultValueSql("1").HasColumnName("TG_INACTIVE");
            builder.Property(x => x.DhInclusion).HasColumnName("DH_INCLUSION");
            builder.Property(x => x.DhChange).HasColumnName("DH_CHANGE");

            this.OnConfigure(builder);
        }

        public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
    }
}
