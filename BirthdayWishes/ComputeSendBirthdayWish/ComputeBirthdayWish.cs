using BirthdayWishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.ComputeSendBirthdayWish
{
    public class ComputeBirthdayWish
    {
        public void SendBirthdayWishes(List<Employee> empList, int[] doNotSend) 
        {
            foreach (Employee employee in empList) 
            {
                 bool dob = IsBirthday(employee);
                 bool withUs = IsEmployeeWithUs(employee);
                 bool doNotWish = DoNotSendWishes(employee, doNotSend);
                bool notified = HasBeenNotified(employee);

                if (IsBirthday(employee) && 
                    IsEmployeeWithUs(employee) &&
                    !DoNotSendWishes(employee, doNotSend) && !HasBeenNotified(employee)
                    )
                {
                    string message = "Happy birthday " + employee.FirstName + " " + employee.LastName;  
                }
            }
        }

        public bool IsBirthday(Employee empList) 
        {
            if (empList.DateOfBirth.Day.Equals(DateTime.Today.Day) && empList.DateOfBirth.Month.Equals(DateTime.Today.Month))
                return true;

            return false;
        }

        /// <summary>
        /// Checks if the employee is still employed and returns true if so.
        /// </summary>
        public bool IsEmployeeWithUs(Employee empList) 
        {
            if (String.IsNullOrEmpty(empList.EmploymentEndDate) && empList.EmploymentStartDate <= DateTime.Today)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the employee do not wish to receive birthday wishes and returns true if so.
        /// </summary>
        public bool DoNotSendWishes(Employee empList, int[] doNotSendArr) 
        {
            for (int i = 0; i < doNotSendArr.Length; i++)
            {
                if (empList.Id == doNotSendArr[i])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the employee has been sent a message or not
        /// </summary>
        
        public bool HasBeenNotified(Employee empList) 
        {
            DateTime lastNotificationDate;
            DateTime.TryParse(empList.LastNotification, out lastNotificationDate);

            if (String.IsNullOrEmpty(empList.LastNotification) || !lastNotificationDate.Date.Equals(DateTime.Today.Date))
                return false;

            return true;
        }
    }
}
