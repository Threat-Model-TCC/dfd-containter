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
        Dfd dfd = context.Dfds.Add(new Dfd { LevelNumber = 0 }).Entity;
        context.SaveChanges();
        return new DfdDTO(dfd.Id);
    }

    public async Task SyncElementsAsync(long dfdId, List<UpsertDfdElementDTO> dtos)
    {
        foreach (var dto in dtos)
        {
            await dfdElementService.CreateOrUpdateAsync(dfdId, dto);
        }
        await context.SaveChangesAsync();
    }

    public DfdDTO CreateChildDfd(CreateDfdChildDTO dto)
    {
        DfdElement processParent = dfdElementService.GetById(dto.ProcessParentId);
        Dfd childDfd = Create(dto.LevelNumber + 1);

        Process process = (Process) processParent;
        process.DfdChildId = childDfd.Id;
        context.SaveChanges();

        return new DfdDTO(childDfd.Id);
    }

    private Dfd Create(int LevelNumber)
    {
        Dfd dfd = context.Dfds.Add(new Dfd { LevelNumber = LevelNumber }).Entity;
        context.SaveChanges();
        return dfd;
    }

    public List<DfdElementResponseDTO> GetDfdById(long id)
    {
        Dfd? dfd = context.Dfds.Find(id);
        if (dfd == null) throw new Exception("DFD não encontrado.");

        return dfdElementService.GetDfdElementsByDfdId(id);
    }
}
