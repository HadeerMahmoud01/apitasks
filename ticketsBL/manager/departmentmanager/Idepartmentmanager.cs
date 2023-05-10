using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketsBL.dtos.departments;
using tickets.DL;


namespace ticketsBL.manager.departmentmanager
{
    public interface Idepartmentmanager
    {
        departmentdetails Getticketwithdepanddeveloper(int id);

    }
}
