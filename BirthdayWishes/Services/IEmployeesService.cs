using BirthdayWishes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.Services
{
    public interface IEmployeesService
    {
        // Task<IEnumerable<Employee>> GetAllEmployees();
        void GetAllEmployees();
    }
}
