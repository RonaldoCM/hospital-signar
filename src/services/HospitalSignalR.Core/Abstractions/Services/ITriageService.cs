using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Abstractions.Services;

public interface ITriageService
{
	Task Create(Patient patient);
	Task Rate(Guid id, Triage triage);
	Task<Patient?> GetNextPatient();
}