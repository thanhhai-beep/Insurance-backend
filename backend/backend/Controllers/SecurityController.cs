﻿using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurity _secu;
        public SecurityController(ISecurity secu)
        {
            _secu = secu;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Login([FromForm] string username, [FromForm] string password)
        {
            if (username is null || password is null)
            {
                return BadRequest(false);
            }
            var login = await _secu.Login(username, password);
            if (login != null)
            {
                return Ok(true);
                //if(login.Roles == true)
                //{
                //    return Ok("Admin");
                //}
                //else
                //{
                //    return Ok("Emp");
                //}
            }
            else
            {
                return Ok(false);
            }
        }
    }
}