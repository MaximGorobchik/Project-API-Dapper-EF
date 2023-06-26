using EFCatalogs.Interfaces;
using main.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace EFCatalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _userService;
        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _userService = usersService;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsersAsync()
        {
            try
            {
                var results = await _userService.GetAllUsersAsync();
                _logger.LogInformation($"Данні успішно отримано");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція поломалась! в цьому винен метод GetAllUsersAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "ось халепа!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);
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
        public async Task<ActionResult> PostEventAsync([FromBody] Users users)
        {
            try
            {
                if (users == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Об'єкт івенту є некоректним");
                }
                var created_id = await _userService.AddUserAsync(users);
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
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Users evnt)
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

                var event_entity = await _userService.GetUserByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _userService.UpdateUserAsync(id, evnt);
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
                var event_entity = await _userService.GetUserByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _userService.DeleteUserAsync(id);
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
