using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThreatModelDfdService.Configs;
using ThreatModelDfdService.Data.DTO;
using ThreatModelDfdService.Model.Context;
using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Services.Impl;

public class DfdService(DfdElementService dfdElementService, MSSQLContext context)
{
    public DfdDTO CreateDfd()
    {
        Dfd dfd = Create(0, null);
        return new DfdDTO(dfd.Id, dfd.DfdParentId, dfd.LevelNumber, []);
    }

    public async Task<List<DfdElementResponseDTO>> SyncElementsAsync(long dfdId, List<UpsertDfdElementDTO> dtos)
    {
        foreach (var dto in dtos)
        {
            await dfdElementService.CreateOrUpdateAsync(dfdId, dto);
        }
        await context.SaveChangesAsync();
        return dfdElementService.GetDfdElementsByDfdId(dfdId);
    }

    public DfdDTO CreateChildDfd(CreateDfdChildDTO dto)
    {
        DfdElement processParent = dfdElementService.GetById(dto.ProcessParentId);
        Dfd childDfd = Create(dto.LevelNumber + 1, processParent.DfdId);

        Process process = (Process) processParent;
        process.DfdChildId = childDfd.Id;
        context.SaveChanges();

        return new DfdDTO(childDfd.Id, childDfd.DfdParentId, childDfd.LevelNumber, []);
    }

    private Dfd Create(int LevelNumber, long? dfdParentId = null)
    {
        Dfd dfd = context.Dfds.Add(new Dfd {
            LevelNumber = LevelNumber,
            DfdParentId = dfdParentId
        }).Entity;
        context.SaveChanges();
        return dfd;
    }

    public DfdDTO GetDfdById(long id)
    {
        Dfd? dfd = context.Dfds.Find(id);
        if (dfd == null) throw new Exception("DFD não encontrado.");

        return new DfdDTO(dfd.Id, dfd.DfdParentId, dfd.LevelNumber, dfdElementService.GetDfdElementsByDfdId(id));
    }
}
