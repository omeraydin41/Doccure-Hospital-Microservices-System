using Doccure.ReviewService.Dtos.ReviewDtos;
using Doccure.ReviewService.Services.ReviewServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _ReviewService;

        public ReviewsController(IReviewService ReviewService)
        {
            _ReviewService = ReviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var values = await _ReviewService.GetAllAsync();
            return Ok(values);
        }

        //
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(string id)
        {
            var value = await _ReviewService.GetByIdAsync(id);
            if (value == null)
            {
                return NotFound("yorum bulunamadı.");
            }
            return Ok(value);
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto dto)
        {
            await _ReviewService.CreateAsync(dto);
            return Ok("yorum başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ReviewService.DeleteAsync(id);
            return Ok("yorum başarıyla silindi.");
        }
    }

}

