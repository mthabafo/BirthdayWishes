using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BirthdayWishes.ComputeSendBirthdayWish;
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
        public async void GetAllEmployees(Task<List<int>> doNotSendList)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var responseString = response.Content.ReadAsStringAsync();

            #region Testing 
            // This region is for quick test purposes for the class ComputeBirthdayWishes

            Employee emp1 = new Employee
            {
                Id = 30,
                FirstName = "John",
                LastName = "Dore",
                DateOfBirth = DateTime.Parse("2006-04-01T00:00:00"),
                EmploymentStartDate = DateTime.Parse("2020-04-01T00:00:00"),
                EmploymentEndDate = "2022-02-28T00:00:00",
                LastNotification = null
            };

            Employee emp2 = new Employee
            {
                Id = 212,
                FirstName = "Luke",
                LastName = "Madani",
                DateOfBirth = DateTime.Parse("2001-03-11T00:00:00"),
                EmploymentStartDate = DateTime.Parse("2010-04-11T00:00:00"),
                EmploymentEndDate = null,
                LastNotification = "2001-03-11T00:00:00"
            };

            Employee emp3 = new Employee
            {
                Id = 101,
                FirstName = "Lizzy",
                LastName = "Castle",
                DateOfBirth = DateTime.Parse("1983-03-11T00:00:00"),
                EmploymentStartDate = DateTime.Parse("2021-03-11T00:00:00"),
                EmploymentEndDate = null,
                LastNotification = null
            };

            Employee emp4 = new Employee
            {
                Id = 100,
                FirstName = "Lizzy",
                LastName = "Castle",
                DateOfBirth = DateTime.Parse("1983-03-11T00:00:00"),
                EmploymentStartDate = DateTime.Parse("2021-01-11T00:00:00"),
                EmploymentEndDate = null,
                LastNotification = "2021-03-11T00:00:00"
            };

            List<Employee> EmpList = new List<Employee>();
            int[] doNotSend = { 101, 200, 111 };

            EmpList.Add(emp1);
            EmpList.Add(emp2);
            EmpList.Add(emp3);
            EmpList.Add(emp4);

            ComputeBirthdayWish obj = new ComputeBirthdayWish();
            obj.SendBirthdayWishes(EmpList, doNotSend);

            #endregion

            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<EmployeesList>(responseStream);

            var result = responseObject?.Employees?.Select(i => new Employee
            {
                Id = i.id,
                FirstName = i.name,
                LastName = i.lastname,
                DateOfBirth = i.dateOfBirth,
                EmploymentStartDate = i.employmentStartDate,
                EmploymentEndDate = i.employmentEndDate,
                LastNotification = i.lastNotification
            });

            ComputeBirthdayWish computeBirthdayWish = new ComputeBirthdayWish();
           // computeBirthdayWish.SendBirthdayWishes(result, doNotSend);
        }
    }
}
