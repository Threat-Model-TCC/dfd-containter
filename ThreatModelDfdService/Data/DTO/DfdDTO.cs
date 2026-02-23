namespace ThreatModelDfdService.Data.DTO;

public record DfdDTO
(
    long Id,
    long? DfdParentId,
    List<DfdElementResponseDTO> Elements
);
