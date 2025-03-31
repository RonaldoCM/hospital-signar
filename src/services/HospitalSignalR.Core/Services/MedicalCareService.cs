using HospitalSignalR.Core.Abstractions.Repositories;
using HospitalSignalR.Core.Abstractions.Services;
using HospitalSignalR.Core.Models;

namespace HospitalSignalR.Core.Services
{
    public class MedicalCareService(IMedicalCareRepository repository) : IMedicalCareService
    {
        public async Task<Patient?> GetNextPatient() => await repository.GetNextPatient();
    }
}
