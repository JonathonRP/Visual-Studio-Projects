using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class EmployeeReport
    {
        public string Employee_Name { get; set; }
        public string Employee_Position { get; set; }
        public float? Employee_Commission { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<EmployeeReport> GetEmployeeReport()
        {
            var result = from Employee in MGO_Entity.Employees
                         select new EmployeeReport()
                         {
                             Employee_Name = Employee.Emp_FName + " " + Employee.Emp_LName,
                             Employee_Position = Employee.Emp_Position,
                             Employee_Commission = Employee.Emp_Commission
                         };

            return result;
        }
    }
}