using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Models.Enums;
using System.Net.Http.Headers;

namespace HospitalManagment.WebAPI.Servcie.Mappers;

public class DoctorMapper
{
    public Doctor ConvertToEntity(CreateDoctorRequest request)
    {
        return new Doctor
        {
            Name = request.Name,
            Branch = request.Branch

        };
    }
    public DoctorResponseDto ConvertToResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto
            (
                Id:doctor.Id,
                Name:doctor.Name,
                Branch:doctor.Branch
            );
    }

    public List<DoctorResponseDto> ConvertToResponseList(List<Doctor> doctors) 
    { 
        return doctors.Select(x=> ConvertToResponseDto(x)).ToList();
    }  
}
