using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Model.Context.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");
        builder.Property(p => p.Title).HasColumnName("title").HasMaxLength(255);
        builder.Property(p => p.Description).HasColumnName("description").HasColumnType("nvarchar(max)");
        builder.Property(p => p.ContextDiagramId).HasColumnName("context_diagram_id");
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
    }
}
