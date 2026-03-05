namespace ThreatModelDfdService.Model.Entity;

public class Project : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long ContextDiagramId { get; set; }
    public DateTime CreatedAt { get; set; }
}
