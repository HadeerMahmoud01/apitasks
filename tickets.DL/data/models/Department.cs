using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickets.DL;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Ticket> tickets { get; set; } = new HashSet<Ticket>();
}
