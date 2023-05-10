using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickets.DL.repo.department
{
    public interface IDepartment
    {
        Department? getticketwithdepanddeveloper(int id);
    }
}
