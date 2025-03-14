using HospitalSignalR.API.Hubs;

namespace HospitalSignalR.API.Mappings;

public static class MappingHub
{
	public static void MapHubs(this WebApplication app)
	{
		app.MapHub<TriageHub>("/hub/triage");
	}
}