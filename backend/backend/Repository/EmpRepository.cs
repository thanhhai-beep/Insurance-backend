using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public class EmpRepository:IEmployee
    {
        private readonly EmployeeDbContext _con;
        public EmpRepository(EmployeeDbContext con)
        {
            _con = con;
        }
        public async Task<Employee> addEmp(Employee emp)
        {
            _con.employees.Add(emp);
            await _con.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> empDetail(int id)
        {
            return await _con.employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> getEmps()
        {
            return await _con.employees.ToListAsync();
        }

        public async Task updateEmp(Employee emp)
        {
            _con.Entry(emp).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }

    }
}
