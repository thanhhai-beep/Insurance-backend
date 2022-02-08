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
        private readonly InsuranceDBContext _con;
        public SecurityRepository(InsuranceDBContext con)
        {
            _con = con;
        }
        public async Task<UserLogin> Login(string username, string password)
        {
            return await _con.UserLogins.FirstOrDefaultAsync(s => s.Username == username && s.PassWord == password);
        }
    }
}
