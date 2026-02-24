namespace ThreatModelDfdService.Data.DTO;

public record DfdDTO
(
    long Id,
    long? DfdParentId,
    int LevelNumber,
    List<DfdElementResponseDTO> Elements
);
