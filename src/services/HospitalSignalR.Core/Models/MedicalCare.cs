using HospitalSignalR.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalSignalR.Core.Models
{
    public class MedicalCare
    {
        [Key]
        public int Id { get; set; }
        public EnumStatus Status { get; set; }
        public required Patient Patient { get; set; }
    }
}
