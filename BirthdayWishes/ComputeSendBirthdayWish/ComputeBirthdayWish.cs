using BirthdayWishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.ComputeSendBirthdayWish
{
    public class ComputeBirthdayWish
    {
        Employee emp1 = new Employee
        {
            FirstName = "John",
            LastName = "Dore",
            DateOfBirth = DateTime.Parse("12-10-88"),
            EmploymentStartDate = DateTime.Parse("01-13-2020"),
            EmploymentEndDate = "28-02-2022",
            LastNotification = null
        };

        Employee emp2 = new Employee
        {
            FirstName = "Luke",
            LastName = "Madani",
            DateOfBirth = DateTime.Parse("09-03-88"),
            EmploymentStartDate = DateTime.Parse("01-13-2020"),
            EmploymentEndDate = null,
            LastNotification = "09-03-2020"
        };

        Employee emp3 = new Employee
        {
            FirstName = "Lizzy",
            LastName = "Castle",
            DateOfBirth = DateTime.Parse("09-03-83"),
            EmploymentStartDate = DateTime.Parse("01-13-2020"),
            EmploymentEndDate = null,
            LastNotification = null
        };

        List<Employee> EmpList = new List<Employee>();      

        public void checkEmployeesWithBirthday() 
        {
            EmpList.Add(emp1);
            EmpList.Add(emp2);
            EmpList.Add(emp3);

            foreach (Employee employee in EmpList) 
            {
                
                if (employee.DateOfBirth.Equals(DateTime.Today) && 
                    String.IsNullOrEmpty(employee.EmploymentEndDate)) 
                {

                }
            }
        }

        public bool IsEmployeeWithUs(Employee empList) 
        {
            if (String.IsNullOrEmpty(empList.EmploymentEndDate) && empList.EmploymentStartDate <= DateTime.Today)
                return true;
            else
                return false;
        }
    }
}
