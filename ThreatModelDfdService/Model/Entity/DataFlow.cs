namespace ThreatModelDfdService.Model.Entity;

public class DataFlow : BaseEntity
{
    public long SourceElementId { get; set; }
    public DfdElement SourceElement { get; set; }

    public long TargetElementId { get; set; }
    public DfdElement TargetElement { get; set; }
}
