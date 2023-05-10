using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apilab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> getCount()
        {
            return Program.count;
        }
    }
}
