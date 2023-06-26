using EFCatalogs.Interfaces;
using main.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace EFCatalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportsService _reportsService;
        public ReportsController(ILogger<ReportsController> logger, IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reports>>> GetAllReportsAsync()
        {
            try
            {
                var results = await _reportsService.GetAllReportsAsync();
                _logger.LogInformation($"Данні успішно отримано");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод GetAllReportsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Reports>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _reportsService.GetReportByIdAsync(id);
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
        public async Task<ActionResult> PostEventAsync([FromBody] Reports reports)
        {
            try
            {
                if (reports == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є некоректним");
                }
                var created_id = await _reportsService.AddReportAsync(reports);
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
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Reports evnt)
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

                var event_entity = await _reportsService.GetReportByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _reportsService.UpdateReportAsync(id, evnt);
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
                var event_entity = await _reportsService.GetReportByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _reportsService.DeleteReportAsync(id);
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
