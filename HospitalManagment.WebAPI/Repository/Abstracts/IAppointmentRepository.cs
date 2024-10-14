using HospitalManagment.WebAPI.Core.Repositories;
using HospitalManagment.WebAPI.Models;

namespace HospitalManagment.WebAPI.Repository.Abstracts;

public interface IAppointmentRepository : IRepository<Appointment,Guid>
{
}
