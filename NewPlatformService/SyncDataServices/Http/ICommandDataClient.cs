using NewPlatformService.DTOs;

namespace NewPlatformService.SyncDataServices.Http
{
	public interface ICommandDataClient
	{
		Task SendPlantformToCommand(PlatformReadDTO platformReadDTO);
	}
}

