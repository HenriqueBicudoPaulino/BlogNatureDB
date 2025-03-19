using Microsoft.AspNetCore.Mvc;
using BlogNatureDB.Entities;
using BlogNatureDB.Services;
using System.Collections.Generic;

namespace BlogNatureDB.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static List<Usuario> users = new List<Usuario>(); // Simulando um banco de dados

        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuario usuario)
        {
            if (users.Exists(u => u.Email == usuario.Email))
                return BadRequest("Usuário já cadastrado com este e-mail.");

            users.Add(usuario);
            return Ok("Usuário cadastrado com sucesso.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var user = users.Find(u => u.Email == usuario.Email && u.Senha == usuario.Senha);
            if (user == null)
                return Unauthorized("Credenciais inválidas.");

            var token = TokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
