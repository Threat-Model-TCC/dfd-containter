using Microsoft.AspNetCore.Mvc;
using ThreatModelDfdService.Data.DTO;
using ThreatModelDfdService.Services.Impl;

namespace ThreatModelDfdService.Controllers;

[ApiController]
[Route("projects")]
public class ProjectController(ProjectService projectService) : ControllerBase
{
    [HttpPost]
    public ActionResult<ProjectResponseDTO> CreateProject([FromBody] CreateProjectDTO dto)
    {
        ProjectResponseDTO payload = projectService.CreateProject(dto);
        return CreatedAtAction(null, null, payload);
    }

    [HttpGet("{id}")]
    public ActionResult<ProjectResponseDTO> GetProjectById([FromRoute] long id)
    {
        return Ok(projectService.GetProjectById(id));
    }

    [HttpPut("{id}")]
    public ActionResult<ProjectResponseDTO> UpdateProject(
        [FromRoute] long id, [FromBody] UpdateProjectDTO dto)
    {
        return Ok(projectService.UpdateProject(id, dto));
    }
}
