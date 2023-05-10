
using tickets.DL;
using tickets.DL.repo.ticket;
using ticketsBL.dtos.departments;

namespace ticketsBL.manager.ticketmanager;

public class ticketmanager : ITicketmanger
{
    private readonly ITicket _ticketrepo;
    public ticketmanager(ITicket ticketrepo)
    {
        _ticketrepo = ticketrepo;
    }

    public int addticket(ticketadd ticket)
    {

        var newticket = new Ticket
        {
            Description = ticket.Description,
            Title = ticket.Title,

        };
        _ticketrepo.addticket(newticket);
        _ticketrepo.SaveChanges();
        return newticket.Id;

    }

    public List<ticketget> GetAll()
    {
        IEnumerable<Ticket> tickets = _ticketrepo.GetAll();
        return tickets.Select(d => new ticketget
        {
            Id = d.Id,
            Description = d.Description,
            Title = d.Title,

        }).ToList();

    }

    public ticketget? GetTicket(int id)
    {
        var ticket = _ticketrepo.GetTicket(id);
        if (ticket == null) return null;
        return new ticketget
        {
            Id = id,
            Description = ticket.Description,
            Title = ticket.Title,
        };
    }



    public void removeticket(int id)
    {

        var ticketfromdb = _ticketrepo.GetTicket(id);
        if (ticketfromdb == null)
        {
            return;
        }
        _ticketrepo.removeticket(ticketfromdb);
        _ticketrepo.SaveChanges();

    }

    public bool updateticket(ticketupdate ticket)
    {

        var updatedticket = _ticketrepo.GetTicket(ticket.Id);
        if (updatedticket == null) return false;
        updatedticket.Description = ticket.Description;
        updatedticket.Title = ticket.Title;
        _ticketrepo.updateticket(updatedticket);
        _ticketrepo.SaveChanges();
        return true;
    }

}
