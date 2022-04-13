using Autorizacao.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Autorizacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AutorizacaoController : ControllerBase
    {
        //System.IdentityModel.Tokens.Jwt

        private readonly UserManager<IdentityUser> _userManager; // Api para gerenciar usuario (CreateAsync)
        private readonly SignInManager<IdentityUser> _signInManager; // Api para logins do usuario (SignInasync, PasswordSignInasync)

        private readonly IConfiguration _configuration;

        public AutorizacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Autorização: " + DateTime.Now.ToLongDateString();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegistrarUsuario(UsuarioDto usuarioDto)
        {
            var user = new IdentityUser()
            {
                UserName = usuarioDto.Email,
                Email = usuarioDto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioDto.Senha);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);
            return Ok(GerarToken(usuarioDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LogarUsuario(UsuarioDto usuarioDto)
        {
            // verifica se credenciais são válidas, lockoutOnFailure = bloqueo, isPersistent = se é persistente
            var result = await _signInManager.PasswordSignInAsync(usuarioDto.Email, usuarioDto.Senha, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(GerarToken(usuarioDto));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login inválido");
                return BadRequest(ModelState);
            }
        }

        private UsuarioTokenDto GerarToken(UsuarioDto usuarioDto)
        {
            // definindo declaracoe para o usuario
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // gerando chave se baseando em um algoritmo simetrico
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // gerando assinatura digital usando o algoritmo HmacSha256 e a chave primaria
            var credencias = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tempo de expiracão do token
            var recuperandoExpiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiracao = DateTime.UtcNow.AddHours(double.Parse(recuperandoExpiracao));

            // classe que representa e gera o token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credencias
            );

            return new UsuarioTokenDto()
            {
                Authenticated = true,
                Expiration = expiracao,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Token criado!"
            };
        }
    }
}
