using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public class SecurityRepository : ISecurity
    {
        private readonly EmployeeDbContext _con;
        public SecurityRepository(EmployeeDbContext con)
        {
            _con = con;
        }
        public async Task<Employee> Login(string username, string password)
        {
            return await _con.employees.FirstOrDefaultAsync(s => s.username == username && s.password == password);
        }
    }
}
