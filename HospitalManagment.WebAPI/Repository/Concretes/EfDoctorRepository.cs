using HospitalManagment.WebAPI.Contexts;
using HospitalManagment.WebAPI.Core.Repositories;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.WebAPI.Repository.Concretes
{
    public class EfDoctorRepository : EfRepositoryBase<BaseDbContext,Doctor,int>,IDoctorRepository
    {
        public EfDoctorRepository(BaseDbContext context) : base(context)
        {
            

        }

        public List<Doctor> GetAllWithAppointments()
        {
            return Context.Doctors
                .Include(d => d.Appointments)  // Appointment varlıklarını dahil et
                .ToList();
        }

        public Doctor? GetByIdWithAppointments(int id)
        {
            return Context.Doctors
                .Include(d => d.Appointments)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
