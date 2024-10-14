using HospitalManagment.WebAPI.Core.Entities;
using HospitalManagment.WebAPI.Models.Enums;


namespace HospitalManagment.WebAPI.Models
{
    public class Doctor : Entity<int>
    {
        public string Name { get; set; }

        public Branch Branch { get; set; }


        public List<Appointment> Appointments { get; set; }
    }
}
