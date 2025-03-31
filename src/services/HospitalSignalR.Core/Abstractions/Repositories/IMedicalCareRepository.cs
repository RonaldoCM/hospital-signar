using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Abstractions.Repositories
{
    public interface IMedicalCareRepository
    {
        Task<Patient?> GetNextPatient();
    }
}
