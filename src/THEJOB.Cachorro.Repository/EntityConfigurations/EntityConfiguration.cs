using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using THEJOB.Cachorro.Domain;

namespace THEJOB.Cachorro.Repository.EntityConfigurations
{
    [ExcludeFromCodeCoverage]
    public class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.UseTpcMappingStrategy();
        }
    }
}