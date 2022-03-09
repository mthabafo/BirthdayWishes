using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayWishes.Services;

namespace BirthdayWishes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IConfiguration configuration, IEmployeesService employeesService) 
        {
            _configuration = configuration;         
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var employeesList = await _employeesService.GetAllEmployees();
            }
            catch (Exception ex) 
            {
            }
            return null;
        }
    }
}
