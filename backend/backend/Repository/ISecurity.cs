using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public interface ISecurity
    {
        Task<Employee> Login(string username, string password);
    }
}
