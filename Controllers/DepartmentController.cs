using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticketsBL;
using ticketsBL.dtos.departments;
using ticketsBL.manager.departmentmanager;

namespace apilab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private Idepartmentmanager _departmentmanger;
        public DepartmentController(Idepartmentmanager manager)
        {
            _departmentmanger = manager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<departmentdetails> Getdepartment (int id)
        {
            departmentdetails? departmentdetails = _departmentmanger.Getticketwithdepanddeveloper(id);
            if(departmentdetails == null) { return null; };
            return departmentdetails;
        }
    }
}
