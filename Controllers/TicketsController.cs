using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticketsBL;
using ticketsBL.manager.ticketmanager;

namespace apilab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketmanger _ticket;
        public TicketsController(ITicketmanger ticket)
        {
            _ticket=ticket;
        }
        [HttpGet]
        [Route("{id}")]
       public ActionResult<ticketget> getbyid(int id)
        {
            ticketget? ticket = _ticket.GetTicket(id);
            if (ticket != null)
            {
                return null;
            }
            return ticket;

        }
        [HttpGet]
        public ActionResult <List<ticketget>> getall()
        {
            return _ticket.GetAll();
        }
        [HttpPut]
        public ActionResult update(ticketupdate ticket)
        {
            var updatedticket = _ticket.updateticket(ticket);
            if (updatedticket == null)
            {
                return NotFound();
            }
            return NoContent();

        }
        [HttpPost]
        public ActionResult add(ticketadd ticket) {
            var newticket = _ticket.addticket(ticket);
            return NoContent();
        }
    }
}
