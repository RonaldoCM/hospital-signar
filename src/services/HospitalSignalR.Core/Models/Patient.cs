using System.ComponentModel.DataAnnotations;
using HospitalSignalR.Core.Enums;

namespace HospitalSignalR.Core.Models;

public class Patient
{
	[Key]
	public int Id { get; set; }
	public string Code { get; set; } = DateTime.Now.ToString("HHmm-ss");
	public required string Name { get; set; }
	public EnumStatus Status { get; set; } = EnumStatus.Start;
	public Triage? Triage { get; set; }
}