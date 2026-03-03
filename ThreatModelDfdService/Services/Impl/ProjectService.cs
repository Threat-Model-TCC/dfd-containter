using ThreatModelDfdService.Data.DTO;
using ThreatModelDfdService.Model.Context;
using ThreatModelDfdService.Model.Entity;
using ThreatModelDfdService.Repositories;

namespace ThreatModelDfdService.Services.Impl;

public class ProjectService(
    MSSQLContext _context,
    IRepository<Project> projectRepository,
    DfdService dfdService
    )
{
    public ProjectResponseDTO CreateProject(CreateProjectDTO dto)
    {
        Dfd contextDiagram = dfdService.Create(0);
        var project = CreateNewProjectEntity(dto, contextDiagram.Id);
        return new ProjectResponseDTO(
            project.Id,
            project.Title,
            project.Description,
            project.ContextDiagramId,
            project.CreatedAt
        );
    }

    public ProjectResponseDTO UpdateProject(long id, UpdateProjectDTO dto)
    {
        Project project = FindById(id);
        project.Title = dto.Name;
        project.Description = dto.Description;
        projectRepository.Update(project);
        return new ProjectResponseDTO(
            project.Id,
            project.Title,
            project.Description,
            project.ContextDiagramId,
            project.CreatedAt
        );
    }

    private Project CreateNewProjectEntity(CreateProjectDTO dto, long ContextDiagramId)
    {
        Project project = new Project
        {
            Title = dto.Name,
            Description = dto.Description,
            ContextDiagramId = ContextDiagramId,
            CreatedAt = DateTime.UtcNow
        };
        return projectRepository.Create(project);
    }

    public ProjectResponseDTO GetProjectById(long id)
    {
        Project project = FindById(id);
        return new ProjectResponseDTO(
            project.Id,
            project.Title,
            project.Description,
            project.ContextDiagramId,
            project.CreatedAt
        );
    }

    public Project FindById(long id)
    {
        Project? project = projectRepository.FindById(id);
        if (project == null) throw new KeyNotFoundException(
            "Project not found with the provided ID: " + id);
        return project;
    }
}
