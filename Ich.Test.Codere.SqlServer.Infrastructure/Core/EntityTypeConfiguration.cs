using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Core
{
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration, IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        public void Configure(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }
    }
    
    public interface IEntityTypeConfiguration
    {
        void Configure(ModelBuilder builder);
    }
}
