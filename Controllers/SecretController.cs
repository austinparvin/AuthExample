using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class SecretController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> UsersOnlyEndpoint()
        {
            return Ok(new { message = "Users only endpoint" });
        }
    }
}