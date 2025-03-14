using HospitalSignalR.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace HospitalSignalR.API.Hubs;

public class TriageHub : Hub
{
	public async Task CallTriage(Patient patient) => await Clients.All.SendAsync("TriageNotification", patient);
	
}