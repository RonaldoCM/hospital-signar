using HospitalSignalR.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace HospitalSignalR.API.Hubs
{
    public class MedicalCareHub : Hub
    {
        public async Task CallMedicalCare(Patient patient) => await Clients.All.SendAsync("MedicalCareNotification", patient);
    }
}
