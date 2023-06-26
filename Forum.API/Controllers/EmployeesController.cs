using main.Models.Categories;
using main.Models.Departments;
using main.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using ReportService.BLL.Interfaces;
using ReportService.DAL.Repositories.Interfaces;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeesService _employeesService;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeesService employeesService)
        {
            _logger = logger;
            _employeesService = employeesService;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetAllEmployeesAsync()
        {
            try
            {
                var results = await _employeesService.GetAllEmployeesAsync();
                _logger.LogInformation($"Данні успішно отримано");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод GetAllEmployeesAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _employeesService.GetEmployeeByIdAsync(id);
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
        public async Task<ActionResult> PostEventAsync([FromBody] Employees employees)
        {
            try
            {
                if (employees == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є некоректним");
                }
                var created_id = await _employeesService.AddEmployeeAsync(employees);
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
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Employees evnt)
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

                var event_entity = await _employeesService.GetEmployeeByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _employeesService.UpdateEmployeeAsync(id, evnt);
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
                var event_entity = await _employeesService.GetEmployeeByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _employeesService.DeleteEmployeeAsync(id);
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
