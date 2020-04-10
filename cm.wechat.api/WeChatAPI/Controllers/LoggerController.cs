using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatAPI.Middleware;

namespace WeChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {        
        [HttpGet]
        [Route("logs")]
        public List<LogMessage> GetAllLogs([FromServices]ILoggerRepository logger)
        {
            return logger.GetAllLogs();
        }
    }
}
