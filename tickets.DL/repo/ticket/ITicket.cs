using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickets.DL.repo.ticket
{
    public interface ITicket
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetTicket(int id);
        void addticket(Ticket ticket);
        void updateticket(Ticket ticket);
        void removeticket(Ticket ticket);
        int SaveChanges();


    }
}
