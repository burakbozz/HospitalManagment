using HospitalManagment.WebAPI.Dtos.Appointments.Requests;
using HospitalManagment.WebAPI.Dtos.Appointments.Responses;
using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Repository.Abstracts;
using HospitalManagment.WebAPI.Repository.Concretes;
using HospitalManagment.WebAPI.Servcie.Abstracts;
using HospitalManagment.WebAPI.Servcie.Mappers;

namespace HospitalManagment.WebAPI.Servcie.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        private AppointmentMapper _appointmentMapper;
        private IDoctorRepository _doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository, AppointmentMapper appointmentMapper)
        {
            _appointmentRepository = appointmentRepository;
            _appointmentMapper = appointmentMapper;
            _doctorRepository = doctorRepository;
        }
        public Appointment? Add(CreateAppointmentRequest dto)
        {
            Appointment appointment = _appointmentMapper.ConvertToEntity(dto);
            Appointment? added = _appointmentRepository.Add(appointment);
            return added;
        }

        public Appointment? Delete(Guid id)
        {
            Appointment? appointment = _appointmentRepository.GetById(id);
            _appointmentRepository.Delete(appointment);
            return appointment;
        }

        public List<AppointmentResponseDto> GetAll()
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();
            List<AppointmentResponseDto> responses = _appointmentMapper.ConvertToResponseList(appointments);
            return responses;
        }

        public AppointmentResponseDto? GetById(Guid id)
        {
            Appointment? appointment = _appointmentRepository.GetById(id);
            AppointmentResponseDto dto = _appointmentMapper.ConvertToResponseDto(appointment);
            return dto;
        }

        public Appointment? Update(Guid id, CreateAppointmentRequest request)
        {
            var existingAppointment = _appointmentRepository.GetById(id);
            if (existingAppointment == null)
            {
                throw new Exception("Appointment not found.");
            }

            
            existingAppointment.PatientName = request.PatientName;
            existingAppointment.AppoinmentDate = request.AppointmentDate;
            existingAppointment.DoctorId = request.DoctorId;
            
            _appointmentRepository.Update(existingAppointment);

            return existingAppointment;
        }

        public Appointment Create(CreateAppointmentRequest request)
        {
            // Bugünün tarihini al
            var today = DateTime.Now;

            // Minimum randevu tarihi olarak 3 gün sonrası belirleniyor
            var minimumAppointmentDate = today.AddDays(3);

            // Eğer randevu tarihi minimum tarihten küçükse hata fırlat
            if (request.AppointmentDate < minimumAppointmentDate)
            {
                throw new Exception($"Appointment date must be at least 3 days from today. Minimum date is {minimumAppointmentDate.ToShortDateString()}.");
            }

            // Randevu alınacak doktorun varlığını kontrol et
            var doctorExists = _doctorRepository.GetById(request.DoctorId) != null;
            if (!doctorExists)
            {
                throw new Exception("The specified doctor does not exist.");
            }

            // Randevu nesnesi oluştur
            Appointment appointment = new Appointment
            {
                PatientName = request.PatientName,
                AppoinmentDate = request.AppointmentDate,
                DoctorId = request.DoctorId
            };

            // Randevuyu veritabanına ekle
            _appointmentRepository.Add(appointment);

            return appointment;
        }
    }
}
