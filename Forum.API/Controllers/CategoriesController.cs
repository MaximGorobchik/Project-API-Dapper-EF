using main.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using ReportService.BLL.Interfaces;
using ReportService.BLL.Services;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ILogger<CategoriesController> logger,
            ICategoriesService categoriesService)
        {
            _logger = logger;
            _categoriesService = categoriesService;

        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategoriesAsync()
        {
            try
            {
                var results = await _categoriesService.GetAllCategoriesAsync();
                _logger.LogInformation($"Данні успішно отримано");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод GetAllCategoriesAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _categoriesService.GetCategoryByIdAsync(id);
                if (result == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод GetByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //POST: api/events
        [HttpPost]
        public async Task<ActionResult> PostEventAsync([FromBody] Categories category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є некоректним");
                }
                var created_id = await _categoriesService.AddCategoryAsync(category);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод PostEventAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //POST: api/events/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Categories evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                var event_entity = await _categoriesService.GetCategoryByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _categoriesService.UpdateCategoryAsync(id, evnt);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод UpdateEventAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _categoriesService.GetCategoryByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _categoriesService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод DeleteByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }
    }
}
