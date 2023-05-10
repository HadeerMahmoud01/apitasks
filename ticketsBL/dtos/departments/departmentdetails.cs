using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketsBL.dtos.departments
{
    public class departmentdetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ticketgetdetails> tickets { get; set; } = new();
    }
}
