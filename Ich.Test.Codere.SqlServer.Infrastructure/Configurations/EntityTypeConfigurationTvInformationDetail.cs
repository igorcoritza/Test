using Ich.Test.Codere.Domain.Models;
using Ich.Test.Codere.SqlServer.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ich.Test.Codere.SqlServer.Infrastructure.Configurations;

public class EntityTypeConfigurationTvInformationDetail : EntityTypeConfiguration<TvInformationDetail>
{
    public override void Configure(EntityTypeBuilder<TvInformationDetail> builder)
    {
        builder.ToTable("TvInformationDetail");
        builder.HasKey(x => x.Id);
    }
}