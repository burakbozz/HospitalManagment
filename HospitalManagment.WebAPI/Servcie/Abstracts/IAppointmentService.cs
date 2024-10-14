using HospitalManagment.WebAPI.Dtos.Appointments.Requests;
using HospitalManagment.WebAPI.Dtos.Appointments.Responses;
using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;

namespace HospitalManagment.WebAPI.Servcie.Abstracts
{
    public interface IAppointmentService
    {
        List<AppointmentResponseDto> GetAll();
        AppointmentResponseDto? GetById(Guid id);
        Appointment? Update(Guid id, CreateAppointmentRequest request);
        Appointment? Add(CreateAppointmentRequest doctor);

        Appointment? Delete(Guid id);
    }
}
