using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Services;

namespace RedeSocial.API.Resources.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private AuthenticateService authenticateService { get; set; }

        public AuthenticateController(AuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [Route("Token")]
        [HttpPost] //passando dados de usuário
        [RequireHttps]//sempre vai vir de uma chamada Https devido informações sensíveis

        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {//Objeto LoginRequest contem user e password
            if (ModelState.IsValid) return await Task.FromResult(BadRequest(ModelState));

            var token = this.authenticateService.AuthenticateUser(loginRequest.UserName, loginRequest.Password);

            if (String.IsNullOrWhiteSpace(token)) return await Task.FromResult(BadRequest("Login ou senha Invalidos"));

            return Ok(new { Token = token });
        
        
        }


       
    }
}
