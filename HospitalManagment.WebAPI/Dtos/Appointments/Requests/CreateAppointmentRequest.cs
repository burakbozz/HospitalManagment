namespace HospitalManagment.WebAPI.Dtos.Appointments.Requests
{
    public record class CreateAppointmentRequest(string PatientName,DateTime AppointmentDate,int DoctorId);
    
}
