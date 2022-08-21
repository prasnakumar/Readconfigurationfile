using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Options;
using Read_configuration_file.Services;

namespace Read_configuration_file.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<UserConditions> _options;
        public HomeController(ILogger<HomeController> logger , IOptions<UserConditions> options )
        {
            _logger = logger;
            _options = options;
        }
        [HttpGet]
        [Route("/Home")]
        public IActionResult LevelController(string input, string logtype)
        {
           
            string message ;
            bool condition = false;
            try
            {


                if (logtype.ToUpper() == "ERROR" && _options.Value.error)
                {


                    _logger.LogError($"Error has occured {input}");
                    message = "Error Printed";
                    condition = true;




                }

                else if (logtype.ToUpper() == "WARNING" && _options.Value.warning)
                {

                    _logger.LogWarning($"warning has occured  {input}");
                    message = "Warning Printed";
                    condition = true;



                }

                else if (logtype.ToUpper() == "DEBUG" && _options.Value.debug)
                {

                    _logger.LogWarning($"warning has occured  {input}");
                    message = "Debug Printed";
                    condition = true;

                }

                else
                {
                    _logger.LogInformation($"NO issues {input}");
                    message = "NOT Printed ";
                }

                return Ok(new { message = input, HasConsolePrinted = message, LogType = logtype, LogCondidtionEnabled = condition });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { status = "Bad Request Invalid Input" ,message=e.Message });
            }
        }
    }
}
