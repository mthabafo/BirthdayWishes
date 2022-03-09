using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.Models
{

    public class EmployeesList
    {
        public EmployeeDetails[] Employees { get; set; }
    }

    public class EmployeeDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime employmentStartDate { get; set; }
        public string employmentEndDate { get; set; }
        public string lastNotification { get; set; }
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

}
