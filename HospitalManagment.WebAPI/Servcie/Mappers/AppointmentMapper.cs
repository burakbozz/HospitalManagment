using HospitalManagment.WebAPI.Dtos.Appointments.Requests;
using HospitalManagment.WebAPI.Dtos.Appointments.Responses;
using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;

namespace HospitalManagment.WebAPI.Servcie.Mappers
{
    public class AppointmentMapper
    {
        public Appointment ConvertToEntity(CreateAppointmentRequest request)
        {
            return new Appointment
            {
                PatientName = request.PatientName,
                AppoinmentDate = request.AppointmentDate,
                DoctorId = request.DoctorId

            };
        }
        public AppointmentResponseDto ConvertToResponseDto(Appointment appointment)
        {
            return new AppointmentResponseDto
                (
                    id: appointment.Id,
                    PatientName: appointment.PatientName,
                    AppointmentDate:appointment.AppoinmentDate,
                    DoctorID:appointment.DoctorId

                    
                );
        }

        public List<AppointmentResponseDto> ConvertToResponseList(List<Appointment> appointments)
        {
            return appointments.Select(x => ConvertToResponseDto(x)).ToList();
        }
    }
}
