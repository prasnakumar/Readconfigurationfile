using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read_configuration_file.Helper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult levelController(string input1, string error)
        {
           
            string message ;
            bool condition = false;
        
          
            if (error.ToUpper() == "ERROR" && _options.Value.error)
            {

               
                    _logger.LogError($"Error has occured {input1}");
                    message= "Error Printed";
                condition = true;




            }

            else if (error.ToUpper() == "WARNING" && _options.Value.warning)
            {
               
                    _logger.LogWarning($"warning has occured  {input1}");
                    message = "Warning Printed";
                condition = true;
               
                

            }

            else if (error.ToUpper() == "DEBUG" && _options.Value.debug)
            {
                
                    _logger.LogWarning($"warning has occured  {input1}");
                    message = "Debug Printed";
                condition = true;
                
            }

            else
            {
                _logger.LogInformation($"NO issues {input1}");
                message = "NOT Printed ";
            }

            return Ok(new { message= input1, HasConsolePrinted=message,LogType= error,LogCondidtionEnabled=condition });
        }
    }
}
