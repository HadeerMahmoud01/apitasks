using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickets.DL.repo.department
{
    public class departmentservices : IDepartment
    {
        private readonly context _context;

        public departmentservices(context context)
        {
            _context = context;
        }
        public Department? getticketwithdepanddeveloper(int id)
        {
            return _context.Departments
            .Include(d => d.tickets).ThenInclude(p => p.Developers)

            .FirstOrDefault(d => d.Id == id);
        }
    }
}
