using HospitalSignalR.API.Modules;

namespace HospitalSignalR.API.Mappings;

public static class MappingModule
{
	public static void MapRoutes(this RouteGroupBuilder app)
	{
		TriageModule.AddRoutes(app);
	}
}