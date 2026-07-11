using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var values = await _doctorService.GetAllAsync();
            return Ok(values);
        }

        //
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var value = await _doctorService.GetByIdAsync(id);
            if (value == null)
            {
                return NotFound("Doktor bulunamadı.");
            }
            return Ok(value);
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            await _doctorService.CreateAsync(dto);
            return Ok("Doktor başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto dto)
        {
            await _doctorService.UpdateAsync(dto);
            return Ok("Doktor bilgileri başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok("Doktor başarıyla silindi.");
        }
    }


}

