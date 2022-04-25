using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techdome.API.Model;
using static Techdome.API.Model.Members;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Techdome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly InlineDatabaseContext Context;
        private readonly UserManager<Model.Members.Member> userManager;
        private readonly RoleManager<Model.Members.Member> roleManager;
        public AuthController(InlineDatabaseContext context, UserManager<Model.Members.Member> usrManager, RoleManager<Model.Members.Member> rlManager)
        {
            Context = context;
            userManager = usrManager;
            roleManager = rlManager;
        }
        [HttpGet("login")]
        public async Model.Members.Member Get([FromQuery] string email, [FromQuery] int id)
        {
            var user = await userManager.FindByEmailAsync(email);
            return Context.Config.Where(row => row.EmailId == email && row.Id == id).FirstOrDefault();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Model.Members.Member newMember)
        {
            var userExist = await userManager.FindByEmailAsync(newMember.EmailId);
            if (userExist != null)
            {
                return Ok();
            }
            var results = await userManager.CreateAsync(newMember);
            if (!results.Succeeded)
            {
                return  StatusCode(StatusCodes.Status500InternalServerError, new { StatusCode = "Error", Message = "User creaction failed" });
            }
            return Ok(new { StatusCode = "Success", Message = "User created succesfully" });
            /*Context.Config.Add(newMember);
            Context.SaveChanges();
            return Context.Config.First();*/
        }
    }
}
