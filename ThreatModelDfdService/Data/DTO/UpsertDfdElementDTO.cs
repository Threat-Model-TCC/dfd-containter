using ThreatModelDfdService.Model.Enums;

namespace ThreatModelDfdService.Data.DTO;

public record UpsertDfdElementDTO (
    long? Id,
    string Name,
    DfdElementType Type,
    decimal XValue,
    decimal YValue,
    decimal Width,
    decimal Height
);
// fazer um json desse dto
    /*
    {
        "id": 1,
        "name": "Element Name",
        "type": "Process", // Pode ser "Process", "DataStore" ou "Actor"
        "xValue": 10.5,
        "yValue": 20.5,
        "width": 100.0,
        "height": 50.0
    }
    */