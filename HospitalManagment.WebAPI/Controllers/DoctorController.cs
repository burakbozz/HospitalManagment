using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Models;
using HospitalManagment.WebAPI.Servcie.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HospitalManagment.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public ActionResult GetAll() 
    {
        List<DoctorResponseDto> doctors = _doctorService.GetAll();
        return Ok(doctors);
    }
    [HttpPost]
    public IActionResult Add([FromBody] CreateDoctorRequest request)
    {
        var created = _doctorService.Add(request);
        return Ok(created);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id) 
    {
        var doctor = _doctorService.GetById(id);
        return Ok(doctor);
    }
    [HttpPut("update/{id}")]
    public IActionResult Update(int id, [FromBody] CreateDoctorRequest request)
    {
        var updatedDoctor = _doctorService.Update(id, request);
        return Ok(updatedDoctor);
    }


    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _doctorService.Delete(id);
        return Ok($"Doctor with ID {id} has been deleted.");
    }




}
