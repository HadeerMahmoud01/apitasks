namespace ticketsBL.manager.ticketmanager;

public interface ITicketmanger
{
    List<ticketget> GetAll();
    ticketget? GetTicket(int id);
    int addticket(ticketadd ticket);
    bool updateticket(ticketupdate ticket);
    void removeticket(int id);


}
