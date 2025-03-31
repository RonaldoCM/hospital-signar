using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Abstractions.Services
{
    public interface IMedicalCareService
    {
        Task<Patient?> GetNextPatient();
    }
}