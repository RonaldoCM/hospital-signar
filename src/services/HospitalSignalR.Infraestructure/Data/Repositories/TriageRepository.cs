using HospitalSignalR.Core.Abstractions.Repositories;
using HospitalSignalR.Core.Enums;
using HospitalSignalR.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSignalR.Infraestructure.Data.Repositories;

public class TriageRepository(HospitalSignalRContextDb context) : ITriageRepository
{
	public async Task Create(Patient patient)
	{
		context.Patients.Add(patient);
		await context.SaveChangesAsync();
	}

	public Task Rate(Guid id, Triage triage)
	{
		throw new NotImplementedException();
	}

	public async Task<Patient?> GetNextPatient()
	{
		var patient = await context.Patients.OrderBy(x => x.Code)
											.FirstOrDefaultAsync(x => x.Status == EnumStatus.Start);
		if(patient == null)
			return null;
		
		patient.Status = EnumStatus.Triage;
		context.Patients.Update(patient);	
		await context.SaveChangesAsync();
		return patient;
	} 
}