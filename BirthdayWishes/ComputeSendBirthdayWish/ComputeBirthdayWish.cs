using BirthdayWishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.ComputeSendBirthdayWish
{
    public class ComputeBirthdayWish
    {
        /// <summary>
        /// Send birthday wishes to employees with 
        /// </summary>
        public void SendBirthdayWishes(List<Employee> empList, int[] doNotSend) 
        {
            List<LastNotification> lastNotifications = new List<LastNotification>();

            foreach (Employee employee in empList) 
            {
                if (IsBirthday(employee) && 
                    IsEmployeeWithUs(employee) &&
                    !DoNotSendWishes(employee, doNotSend) && !HasBeenNotified(employee)
                    )
                {                  
                    lastNotifications.Add(UpdateLastNotification(employee)); // Updates last notification
                   
                    string message = String.Format("Happy birthday {0} {1}", employee.FirstName, employee.LastName);
                    Console.WriteLine(message); // This message will be sent to email, for now we will display it on Console to keep things simple
                }
            }
        }

        /// <summary>
        /// Checks if today's date is a birthday to the provided employee
        /// </summary>
        public bool IsBirthday(Employee empList) 
        {
            if ((empList.DateOfBirth.Day.Equals(DateTime.Today.Day) && empList.DateOfBirth.Month.Equals(DateTime.Today.Month)) ||
                (!IsLeapYear() && DateTime.Today.Day == 28 && DateTime.Today.Month == 2) && 
                (empList.DateOfBirth.Day == 29 && empList.DateOfBirth.Month == 2))
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

        /// <summary>
        /// Checks if the current year is leap or not
        /// </summary>
        public bool IsLeapYear() 
        {
            int Year = DateTime.Today.Year;

            if (((Year % 4 == 0) && (Year % 100 != 0)) || (Year % 400 == 0))
                return true;

            return false;
        }

        /// <summary>
        /// Updates the LastNofication when the employee has been notified
        /// </summary>
        /// <returns> The employee Id and LastNotification only </returns>
        public LastNotification UpdateLastNotification(Employee employee) 
        {
            LastNotification lastNotification = new LastNotification();
            lastNotification.Id = employee.Id; 
            lastNotification.LastNotificationDate = DateTime.Now.ToString();

            return lastNotification;
        }
    }
}
