using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Model.Context.Configurations;

public class DataStoreConfiguration : IEntityTypeConfiguration<DataStore>
{
    public void Configure(EntityTypeBuilder<DataStore> builder)
    {
        builder.ToTable("data_stores");
    }
}
