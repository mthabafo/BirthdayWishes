using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BirthdayWishes.Models;
using BirthdayWishes.Services;
//using Newtonsoft.Json;

namespace BirthdayWishes.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClient _httpClient;

        public EmployeesService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress.AbsoluteUri);
            var res = response.Content.ReadAsStringAsync();

            var resStream = await response.Content.ReadAsStreamAsync();

            var responseObject = await JsonSerializer.DeserializeAsync<EmployeesList>(resStream);

            var result = responseObject?.Employees?.Select(i => new Employee
            {
                Id = i.Id,
                FirstName = i.name,
                LastName = i.lastname,
                DateOfBirth = i.dateOfBirth,
                EmploymentStartDate = i.employmentStartDate,
                EmploymentEndDate = i.employmentEndDate,
                LastNotification = i.lastNotification

            });

            return result;
        }
    }
}
