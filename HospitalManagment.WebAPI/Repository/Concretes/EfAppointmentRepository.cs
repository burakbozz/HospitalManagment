using HospitalManagment.WebAPI.Contexts;
using HospitalManagment.WebAPI.Core.Repositories;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.WebAPI.Repository.Concretes
{
    public class EfAppointmentRepository : EfRepositoryBase<BaseDbContext,Appointment,Guid>,IAppointmentRepository
    {
        public EfAppointmentRepository(BaseDbContext context) : base(context)
        {
            
        }

        public List<Appointment> GetAllWithDoctors()
        {
            return Context.Appointments
                .Include(a => a.Doctor)  // Doctor varlığını dahil et
                .ToList();
        }

        
    }
}
