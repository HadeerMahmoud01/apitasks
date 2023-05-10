using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace tickets.DL.repo.ticket
{
    public class ticketservices : ITicket
    {
        private readonly context _context;

        public ticketservices(context context)
        {
            _context = context;
        }
        public void addticket(Ticket ticket)
        {
            _context.Set<Ticket>().Add(ticket);
        }

        public IEnumerable<Ticket> GetAll()
        {

            return _context.Set<Ticket>().AsNoTracking();
        }

        public Ticket? GetTicket(int id)
        {
            return _context.Set<Ticket>().Find(id);
        }



        public void removeticket(Ticket ticket)
        {
            _context.Set<Ticket>().Remove(ticket);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void updateticket(Ticket ticket)
        {

        }
    }
}
