using HospitalSignalR.Core.Abstractions.Repositories;
using HospitalSignalR.Core.Enums;
using HospitalSignalR.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSignalR.Infraestructure.Data.Repositories
{

    public class MedicalCareRepository(HospitalSignalRContextDb context) : IMedicalCareRepository
    {
        public async Task<Patient?> GetNextPatient()
        {
            var patient = await context.Patients.OrderByDescending(x => x.Triage != null ? x.Triage.Rate : 0)
                                                .FirstOrDefaultAsync(x => x.Status == EnumStatus.Triage);
            if (patient == null)
                return null;

            patient.Status = EnumStatus.Medical;
            context.Patients.Update(patient);
            await context.SaveChangesAsync();
            return patient;
        }

    }
}
