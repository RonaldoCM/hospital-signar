using HospitalSignalR.Core.Abstractions.Services;

namespace HospitalSignalR.API.Modules
{
    public static class MedicalCareModule
    {
        public static void AddRoutes(RouteGroupBuilder app)
        {
            var medicalCareGroup = app.MapGroup("medicalCare");

            medicalCareGroup.MapGet("next", GetNextPatient);
        }

        private static async Task<IResult> GetNextPatient(IMedicalCareService service) => Results.Ok(await service.GetNextPatient());

    }
}
