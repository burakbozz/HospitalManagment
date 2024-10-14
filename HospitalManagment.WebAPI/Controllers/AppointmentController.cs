using HospitalManagment.WebAPI.Dtos.Appointments.Requests;
using HospitalManagment.WebAPI.Dtos.Appointments.Responses;
using HospitalManagment.WebAPI.Dtos.Doctors.Requests;
using HospitalManagment.WebAPI.Dtos.Doctors.Responses;
using HospitalManagment.WebAPI.Servcie.Abstracts;
using HospitalManagment.WebAPI.Servcie.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagment.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService )
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("getall")]
    public ActionResult GetAll()
    {
        List<AppointmentResponseDto> appointments = _appointmentService.GetAll();
        return Ok(appointments);
    }
    [HttpPost]
    public IActionResult Add([FromBody] CreateAppointmentRequest request)
    {
        var created = _appointmentService.Add(request);
        return Ok(created);
    }
    [HttpGet("{id:Guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var appointment = _appointmentService.GetById(id);
        return Ok(appointment);
    }
    [HttpPut("update/{id}")]
    public IActionResult Update(Guid id, [FromBody] CreateAppointmentRequest request)
    {
        var updatedAppointment = _appointmentService.Update(id, request);
        return Ok(updatedAppointment);
    }
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        _appointmentService.Delete(id);
        return Ok($"Doctor with ID {id} has been deleted.");
    }
    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateAppointmentRequest request)
    {
        try
        {
            var newAppointment = _appointmentService.Add(request);
            return CreatedAtAction(nameof(Create), new { id = newAppointment.Id }, newAppointment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
