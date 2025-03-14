using System.ComponentModel.DataAnnotations;
using HospitalSignalR.Core.Enums;

namespace HospitalSignalR.Core.Models;

public class Triage
{
	[Key]
	public int Id { get; set; }
	public EnumRate Rate { get; set; }
}