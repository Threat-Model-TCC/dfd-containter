using Microsoft.AspNetCore.Mvc;
using ThreatModelDfdService.Data.DTO;
using ThreatModelDfdService.Services.Impl;

namespace ThreatModelDfdService.Controllers;

[ApiController]
[Route("dfd")]
public class DfdController(DfdService service) : ControllerBase
{
    [HttpPost]
    public ActionResult<DfdDTO> CreateDfd()
    {
        DfdDTO payload = service.CreateDfd();
        return CreatedAtAction(null, null, payload);
    }

    [HttpPut("{id}/elements")]
    public async Task<IActionResult> UpdateElements(long id, [FromBody] List<UpsertDfdElementDTO> elements)
    {
        await service.SyncElementsAsync(id, elements);
        return NoContent();
    }

    [HttpGet("{id}")]
    public ActionResult<List<DfdElementResponseDTO>> GetDfdById(long id)
    {
        return Ok(service.GetDfdById(id));
    }
}
