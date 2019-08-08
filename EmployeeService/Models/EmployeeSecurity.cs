using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDA;

namespace EmployeeService.Models
{
    public class EmployeeSecurity
    {

        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities ctx = new EmployeeDBEntities())
            {
                return ctx.Users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && u.Password.Equals(password));
            }
        }
    }
}