using HospitalManagment.WebAPI.Core.Entities;

namespace HospitalManagment.WebAPI.Models
{
    public class Appointment : Entity<Guid>
    {
        public string? PatientName { get; set; }

        public DateTime AppoinmentDate { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
