using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public string EmploymentEndDate { get; set; }
        public string LastNotification { get; set; }

    }
}

