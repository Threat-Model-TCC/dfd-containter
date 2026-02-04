using ThreatModelDfdService.Model.Enums;

namespace ThreatModelDfdService.Data.DTO;

public record DfdElementResponseDTO(
    long Id,
    string ElementName,
    DfdElementType Type,
    decimal PositionX,
    decimal PositionY,
    decimal Width,
    decimal Height
);
