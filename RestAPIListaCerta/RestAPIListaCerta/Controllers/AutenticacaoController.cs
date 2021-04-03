using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPIListaCerta.Data.VO;
using RestAPIListaCerta.Services;

namespace RestAPIListaCerta.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class AutenticacaoController : ControllerBase
    {
        private ILoginService _loginService;

        public AutenticacaoController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request (user nao pode ser null)");

            var token = _loginService.ValidateCredentials(user);

            //Token inválido
            if (token == null) return Unauthorized();

            //Token válido
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid client request (refresh token nao pode ser null)");

            var token = _loginService.ValidateCredentials(tokenVO);

            //Token inválido
            if (token == null) return BadRequest("Invalid client request (refresh token nao pode ser null)");
            //Token válido
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;
            var result = _loginService.RevokeToken(userName);

            if (!result) return BadRequest("Invalid client request (refresh token nao pode ser null)");
            
            return NoContent();
        }
    }
}
