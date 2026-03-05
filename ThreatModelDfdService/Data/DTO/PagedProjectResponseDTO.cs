namespace ThreatModelDfdService.Data.DTO;

public record PagedProjectResponseDTO(
    int CurrentPage,
    int Pages,
    List<ProjectResponseDTO> Projects
);
