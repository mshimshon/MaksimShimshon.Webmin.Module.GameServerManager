using CoreMap;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.Entites;
using GameServerManager.Dashboard.Features.Lifecycle.Domain.ValueObjects;

namespace GameServerManager.Dashboard.Features.Lifecycle.Infrastruture.Servicers.DTOs.Responses.Mapping;

public class StatusResourceResponseToStatusSystemInfoEntity : ICoreMapHandler<StatusResourcesResponse, SystemInfoEntity>
{
    public SystemInfoEntity Handler(StatusResourcesResponse data, ICoreMap alsoMap)
    {
        return new SystemInfoEntity()
        {
            Disk = data.Storage != default ? new SystemDisk(data.Storage.Used, data.Storage.Total) : new SystemDisk(0, 0),
            Memory = data.Memory != default ? new SystemMemory(data.Memory.Used, data.Memory.Total) : new SystemMemory(0, 0),
            Processor = data.Cpu != default ? new SystemProcessor(data.Cpu.Usage, data.Cpu.Cores, data.Cpu.Model) : new SystemProcessor(0, 0, "N/A")
        };

    }
}
