using apilab3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apilab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private UserManager<Lawyer> _usermanager;

        public DataController(UserManager<Lawyer> userManager) {

          _usermanager=userManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> getdata()
        {
            var user=await _usermanager.GetUserAsync(User);
            return Ok(new string[]
            {
                "sara",
                user.Email,
                user.UserName,
                user.specialization

            });
        }

        [HttpGet]
        [Authorize (policy:"manager")]
        [Route("managers")]
        public ActionResult getmanagerdata()
        {
            return Ok(new string[]
            {
                "manager data"
            });
        }

        [HttpGet]
        [Authorize (policy:"lawyer")]
        [Route("users")]

        public ActionResult getusers()
        {
            return Ok(new string[]
            {
                "users"
            });
        }













    }
}
