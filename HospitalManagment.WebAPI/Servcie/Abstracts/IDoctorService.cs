using HospitalManagment.WebAPI.Core.Entities;
using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;
using System.Security.Cryptography;

namespace HospitalManagment.WebAPI.Servcie.Abstracts
{
    public interface IDoctorService
    {
        List<DoctorResponseDto> GetAll();
        DoctorResponseDto? GetById(int id);
        Doctor? Update(int id,CreateDoctorRequest request);
        Doctor? Add(CreateDoctorRequest doctor);

        Doctor? Delete(int id);
    }
}
