using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using System;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : Controller
    {

        private LogsService _logsService;
        public LogsController(LogsService logsService)
        {
            _logsService = logsService;
        }


        [HttpGet("GetLogs")]
        public IActionResult GetAll()
        {
            try
            {
                var alllogs = _logsService.GetLogs();
                return Ok(alllogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
