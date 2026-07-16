using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService appointmentService)//DI için constructor
        {
            _service = appointmentService;
        }

        // Tüm randevuları getir
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // Id'ye göre randevu getir
        [HttpGet("GetAppointemen")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var value = await _service.GetByIdAsync(id);
            if (value==null)
            {
                return NotFound("randevu bulunamadı");
            }
            return Ok(value);
        }

        // Yeni randevu oluştur
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Randevu başarıyla oluşturuldu.");
        }

        // Randevu güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Randevu başarıyla güncellendi.");
        }

        // Randevu sil
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Randevu başarıyla silindi.");
        }
    }
}

