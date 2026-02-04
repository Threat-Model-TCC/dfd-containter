using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Model.Context.Configurations;

public class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("processes");
        builder.Property(p => p.DfdChildId).HasColumnName("dfd_child_id");
    }
}