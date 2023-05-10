using apilab3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using apilab3.dtos;
using System.Security.Claims;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace apilab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Lawyer> _usermanager;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration,UserManager<Lawyer> userManager) {
        
            _usermanager=userManager;
            _configuration = configuration;
        
        }

        //register admin
        [HttpPost]
        [Route("registeradmin")]
        public async Task<ActionResult> registeradmin(registerdata registerdata)
        {
            var newlawyer = new Lawyer
            {
                UserName = registerdata.username,
                Email = registerdata.email,
                specialization = registerdata.specialization,

            };
            var createdclaim = await _usermanager.CreateAsync(newlawyer, registerdata.password);
            if (!createdclaim.Succeeded)
            {
                return BadRequest();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,newlawyer.Id),
                new Claim(ClaimTypes.Role,"admin"),
            };
            await _usermanager.AddClaimsAsync(newlawyer, claims);

            return NoContent();

        }
        //register user
        [HttpPost]
        [Route("registerlawyer")]
        public async Task<ActionResult> registerlawyer (registerdata registerdata)
        {
            var newlawyer = new Lawyer
            {
                UserName = registerdata.username,
                Email = registerdata.email,
                specialization= registerdata.specialization,

            };
            var createdclaim = await _usermanager.CreateAsync(newlawyer, registerdata.password);
            if (!createdclaim.Succeeded)
            {
                return BadRequest();
            }
            var claims=new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,newlawyer.Id),
                new Claim(ClaimTypes.Role,"lawyer"),
            };
            await _usermanager.AddClaimsAsync(newlawyer, claims);

            return NoContent();

        }
        //login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<tokendata>> login(logindata logindata)
        {
            var loginuser=  await _usermanager.FindByNameAsync(logindata.username);

            if (logindata == null)
            {
                return BadRequest();
            }
            bool passwordlogin= await _usermanager.CheckPasswordAsync(loginuser,logindata.password);
            if (!passwordlogin)
            {
                return BadRequest();

            }
            var logintoken = await _usermanager.GetClaimsAsync(loginuser);

            return GenerateToken(logintoken);
        }

        private ActionResult<tokendata> GenerateToken(IList<Claim> logintoken)
        {
            var keystring = _configuration.GetValue<string>("SecretKey");
            var keybytes=Encoding.ASCII.GetBytes(keystring);
            var key = new SymmetricSecurityKey(keybytes);
            var signdata= new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var expiredate = DateTime.Now.AddMinutes(10);
            var jwt = new JwtSecurityToken
            (
                expires: expiredate,
                claims: logintoken,
                signingCredentials: signdata


                );


            var tokenhandeller=new JwtSecurityTokenHandler();
            var tokenstring= tokenhandeller.WriteToken(jwt);
            return new tokendata
            {
                token = tokenstring,
                expiredate = expiredate
            };





























        }
    }
}
