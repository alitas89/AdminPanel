using AdminPanel.Guvenlik.AuthenticationKismi;
using AdminPanel.WebAPI.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminPanel.WebAPI.Controllers.Other
{
    
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAuthentication _authentication;
        public LoginController() : base()
        {
            _authentication = new Authentication();
        }

       

        [HttpPost()]
        [Route("[controller]/[Action]/")]
        public async Task<IActionResult> CreateEmailPassword(EmailPassword emailPassword)//(string email, string password)
        {

            if (emailPassword != null)
            {
                var resource = await _authentication.CreateEmailPassword(emailPassword.Email, emailPassword.Password);

                return dondur(resource);
            }
            else
                return BadRequest("Geçersiz parametre");
        }

        [HttpPost]
        [Route("[controller]/[Action]/")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(EmailPassword emailPassword)
        {
            if (emailPassword != null)
            {
                var kullaniciTalepleri = User.Claims;
                string? strEmailId = kullaniciTalepleri.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier)?.Value;
                var resource = await _authentication.UpdatePassword(emailPassword.Email, emailPassword.Password, int.Parse(strEmailId!));
                return dondur(resource); 
            }
            else
                return BadRequest("Geçersiz parametre");
        }

        [HttpPost()]
        [Route("[controller]/[Action]/")]
        public async Task<IActionResult> CreateAccessToken(EmailPassword emailPassword)
        {
            if (emailPassword != null)
            {
                var resource = await _authentication.CreateAccessToken(emailPassword.Email, emailPassword.Password);
                return dondur(resource); 
            }
            else
                return BadRequest("Geçersiz parametre");
        }

        [HttpPost()]
        [Route("[controller]/[Action]/")]
        public async Task<IActionResult> CreateAccessTokenByRefreshToken(EmailRefreshToken emailRefreshToken)
        {
            if (emailRefreshToken != null)
            {
                var resource = await _authentication.CreateAccessTokenByRefreshToken(emailRefreshToken.Email, emailRefreshToken.RefreshToken);
                return dondur(resource); 
            }
            else
                return BadRequest("Geçersiz parametre");
        }

        [HttpPost()]
        [Route("[controller]/[Action]/")]
        [Authorize]
        public async Task<IActionResult> RemoveRefreshToken(EmailRefreshToken emailRefreshToken)
        {
            if (emailRefreshToken != null)
            {
                var resource = await _authentication.RemoveRefreshToken(emailRefreshToken.Email, emailRefreshToken.RefreshToken);
                return dondur(resource); 
            }
            else
                return BadRequest("Geçersiz parametre");
        }

        private IActionResult dondur(dynamic resource)
        {
            IActionResult result;
            if (resource.Success)
            {
                result = Ok(resource.Data);
            }
            else
                result = BadRequest(resource.Message);

            return result;
        }
    }
}
