using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Abstractions.Repositories
{
    public interface ITriageRepository
    {
        Task Create(Patient patient);
        Task Rate(Guid id, Triage triage);
        Task<Patient?> GetNextPatient();
    }
}