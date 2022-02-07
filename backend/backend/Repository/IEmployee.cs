using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> getEmps();
        Task<Employee> empDetail(int id);
        Task<Employee> addEmp(Employee emp);
        Task updateEmp(Employee emp);

    }
}
