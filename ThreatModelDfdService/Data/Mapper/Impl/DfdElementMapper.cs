using ThreatModelDfdService.Data.Converter.Contract;
using ThreatModelDfdService.Data.DTO;
using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Data.Converter.Impl;

public class DfdElementMapper : IParser<DfdElement, DfdElementResponseDTO>
{
    public DfdElementResponseDTO Parse(DfdElement origin)
    {
        if(origin == null) return null;
        return new DfdElementResponseDTO(
            origin.Id,
            origin.Name,
            origin.Type,
            origin.XValue,
            origin.YValue,
            origin.Width,
            origin.Height
        );
    }

    public List<DfdElementResponseDTO> ParseList(List<DfdElement> origin)
    {
        if(origin == null) return null;
        return origin.Select(Parse).ToList();
    }
}
