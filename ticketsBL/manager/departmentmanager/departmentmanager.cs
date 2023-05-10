using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tickets.DL;
using tickets.DL.repo.department;
using ticketsBL.dtos.departments;

namespace ticketsBL.manager.departmentmanager
{
    public class departmentmanager : Idepartmentmanager
    {
        private readonly IDepartment _departmentservices;

        public departmentmanager(IDepartment departmentservices)
        {
            _departmentservices = departmentservices;
        }


        public departmentdetails? Getticketwithdepanddeveloper(int id)
        {
            Department? dep = _departmentservices.getticketwithdepanddeveloper(id);
            if (dep == null) return null;
            return new departmentdetails
            {
                Id = dep.Id,
                Name = dep.Name,
                tickets = dep.tickets.Select(d => new ticketgetdetails
                {
                    Id = d.Id,
                    Description = d.Description,
                    Title = d.Title,
                    developerscount = d.Developers.Count
                }).ToList()

            };
        }
    }
}
