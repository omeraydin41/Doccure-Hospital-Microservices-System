using Doccure.PrescriptionService.Dtos.PrescriptionDtos;
using Doccure.PrescriptionService.Services.PrescriptionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;//test edilecek servisin erişim için nesnesini aldık 

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto dto)
        {
            await _prescriptionService.CreateAsync(dto);//gelen değeri ekle - CreateAsync IPrescriptionService içinedeki method 
            return Ok("Reçete başarıyla oluşturuldu.");//ok dön 
        }

        [HttpGet("{GetById}")]
        public async Task<IActionResult> GetById(int id)//id ye gore reçete arama 
        {
            var value = await _prescriptionService.GetByIdAsync(id);
            if (value == null) 
                return NotFound("reçete bulunamadı");
            return Ok(value);
        }

        [HttpGet("GetAppointmentId")]
        public async Task<IActionResult> GetByAppointmentId(int id)//muhaneye gore reçete getirme 
        {
            var value = await _prescriptionService.GetByAppointmentIdAsync(id);
            if (value == null)
                return NotFound("reçete bulunamadı");
            return Ok(value);
        }

        [HttpGet("GetByPatientId")]
        public async Task<IActionResult> GetByPatientId(string id)//id ye gore hasta arama 
        {
            var values = await _prescriptionService.GetByPatientIdAsync(id);
            return Ok(values);
        }
    }
}
