using Microsoft.AspNetCore.Mvc;
using ThreatModelDfdService.Services;

namespace ThreatModelDfdService.Controller;

[ApiController]
public class DfdElementController(DfdElementService dfdElementService) : ControllerBase
{

    [HttpDelete("dfd-elements/{id}")]
    public IActionResult DeleteDfdElement(long id)
    {
        Console.WriteLine("Deleting DFD Element...");
        dfdElementService.DeleteDfdElement(id);
        return NoContent();
    }
}
