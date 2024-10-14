using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Repository.Abstracts;
using HospitalManagment.WebAPI.Servcie.Abstracts;
using HospitalManagment.WebAPI.Servcie.Mappers;
using System.Net.Http.Headers;

namespace HospitalManagment.WebAPI.Servcie.Concretes
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;
        private DoctorMapper _doctorMapper;
        public DoctorService(IDoctorRepository doctorRepository,DoctorMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _doctorMapper = mapper;
        }

        public Doctor? Add(CreateDoctorRequest dto)
        {
            Doctor doctor = _doctorMapper.ConvertToEntity(dto);
            Doctor? added = _doctorRepository.Add(doctor);
            return added;
        }

        public Doctor? Delete(int id)
        {   
            Doctor? doctor = _doctorRepository.GetById(id);
            _doctorRepository.Delete(doctor);
            return doctor;
        }

        public List<DoctorResponseDto> GetAll()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            List<DoctorResponseDto> responses = _doctorMapper.ConvertToResponseList(doctors);
            return responses;
            
            
        }

        public DoctorResponseDto? GetById(int id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            DoctorResponseDto dto = _doctorMapper.ConvertToResponseDto(doctor);
            return dto;
        }

        public Doctor? Update(int id, CreateDoctorRequest request)
        {

            var existingDoctor = _doctorRepository.GetById(id);
            if (existingDoctor == null)
            {
                throw new Exception("Doctor not found.");
            }
            existingDoctor.Name = request.Name;
            existingDoctor.Branch = request.Branch;
            
            _doctorRepository.Update(existingDoctor);

            return existingDoctor;
        }
    }
}
