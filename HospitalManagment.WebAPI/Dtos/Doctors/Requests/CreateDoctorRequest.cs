using HospitalManagment.WebAPI.Models.Enums;

namespace HospitalManagment.WebAPI.Dtos.Doctors.Requests;

public record CreateDoctorRequest(string Name,Branch Branch);

