using HospitalManagment.WebAPI.Models.Enums;

namespace HospitalManagment.WebAPI.Dtos.Appointments.Responses
{
    public record AppointmentResponseDto(Guid id, string PatientName,DateTime AppointmentDate,int DoctorID);

}
