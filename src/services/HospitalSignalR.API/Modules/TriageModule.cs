using HospitalSignalR.Core.Models;
using HospitalSignalR.Core.Abstractions.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalSignalR.API.Modules;

public static class TriageModule
{
	public static void AddRoutes(RouteGroupBuilder app)
	{
		var triageGroup = app.MapGroup("triage");
		triageGroup.MapPost("", Create);
		triageGroup.MapPut("{id:Guid}", Rate);
		triageGroup.MapGet("next", GetNextPatient);
	}

	private static async Task<IResult> Create(Patient patient, ITriageService service)
	{
		await service.Create(patient);
		return Results.Created($"/triage/{patient.Id}", patient);
	}

	private static async Task<IResult> Rate(
		Guid id, 
		Triage triage,
		ITriageService service)
	{
		await service.Rate(id, triage);
		return Results.Ok();
	}

	private static async Task<IResult> GetNextPatient(ITriageService service) => Results.Ok(await service.GetNextPatient());
}