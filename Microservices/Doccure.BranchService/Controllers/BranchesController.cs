using Doccure.BranchService.Dtos.BranchDtos;
using Doccure.BranchService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.BranchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        //[Authorize(Roles ="Admin")]//Authorize : sistemde yetki belirleme yapılır
                                   //| Bu endpoint'e sadece kimliği doğrulanmış (authenticated) VE Admin rolüne sahip kullanıcılar erişebilir.
        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto dto)
        {
            await _branchService.CreateAsync(dto);
            return Ok( "Ekleme Başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteAsync(id);
            return Ok("Silme Başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto dto)
        {
            await _branchService.UpdateAsync(dto);
            return Ok("Güncelleme Başarılı.");
        }

        [HttpGet("GetBranch")]//CONTROLLEDEN APİ YAZARKEN BİRDEN FAZLA GET KULLNILIRSA HEPSİNİN ATTRİBUTESİ OLMALI (GetBranch)
        public async Task<IActionResult> GetBranchById(string id)//dışardan gelen id değeri ile branch ıd eşleşirse branch bilgilerini getirir
        {
            var value = await _branchService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
