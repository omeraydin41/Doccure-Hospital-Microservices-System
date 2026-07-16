using Doccure.AppointmentService.Dtos.AppointmentDetail;
using Doccure.AppointmentService.Services.AppointmentDetailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailController : ControllerBase
    {
        private readonly IAppointmentDetailService _appointmentDetailService;

        public AppointmentDetailController(IAppointmentDetailService appointmentDetailService)
        {
            _appointmentDetailService = appointmentDetailService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(CreateAppointmentDetailDto dto)
        {
            await _appointmentDetailService.CreateAsync(dto);
            return Ok("randevu başarıyla oluşturuldu");
        }


        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetAppointmentDetail(int id)
        {
            var value = await _appointmentDetailService.GetAllAppointmentDetailAsync(id);
            return Ok(value);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDetailDto dto)
        {
            await _appointmentDetailService.UpdateAsync(dto);
            return Ok("Güncelleme başarılı");
        }
    }
}
