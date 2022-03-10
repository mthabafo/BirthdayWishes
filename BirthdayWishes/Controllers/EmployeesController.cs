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
        private readonly IDoNotSendService _doNotSendService;
        private readonly IEmployeesService _employeesService;
        
        public EmployeesController(IDoNotSendService doNotSendService, IEmployeesService employeesService) 
        {
            _doNotSendService = doNotSendService;
            _employeesService = employeesService;
        }

        [HttpGet]
        public void Get() 
        {
            try
            {
                Task<List<int>> doNoSendList = _doNotSendService.GetAllDoNotSend();

                // We pass the doNotSendList list as an argument 
                _employeesService.GetAllEmployees(doNoSendList);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
