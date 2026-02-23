namespace ThreatModelDfdService.Data.DTO;

public record CreateDfdChildDTO (
    long ProcessParentId,
    int LevelNumber
);
