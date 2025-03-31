using HospitalSignalR.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSignalR.Infraestructure.Data;

public class HospitalSignalRContextDb : DbContext
{
	public HospitalSignalRContextDb(DbContextOptions<HospitalSignalRContextDb> options): base(options) { ; }

	public DbSet<Patient> Patients { get; set; }
	public DbSet<Triage> Triages { get; set; }
	public DbSet<MedicalCare> Medicals { get; set; }
}