using HospitalSignalR.Core.Abstractions.Repositories;
using HospitalSignalR.Core.Abstractions.Services;
using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Services;

public class TriageService(ITriageRepository repository) : ITriageService
{
	public Task Create(Patient patient) => repository.Create(patient);
	public async Task Rate(Guid id, Triage triage) => await repository.Rate(id, triage);
	public async Task<Patient?> GetNextPatient() => await repository.GetNextPatient();
}