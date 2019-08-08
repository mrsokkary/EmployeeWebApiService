using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EmployeeDA;
using EmployeeService.Models;

namespace EmployeeService.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        //public IEnumerable<Employee> GetAll()
        //{
        //    using (EmployeeDBEntities ctx = new EmployeeDBEntities())
        //    {
        //        return ctx.Employees.ToList();
        //    }
        //}

       
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities ctx = new EmployeeDBEntities())
            {
                return ctx.Employees.ToList();
            }
        }


        //[BasicAuthentication] 
        //public HttpResponseMessage Get(string gender = "All")
        //{
        //    string userName = Thread.CurrentPrincipal.Identity.Name;

        //    using (EmployeeDBEntities ctx = new EmployeeDBEntities())
        //    {
        //        switch (userName.ToLower())
        //        {
        //            //case "all":
        //            //    return Request.CreateResponse(HttpStatusCode.OK, ctx.Employees.ToList());
        //            case "male":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    ctx.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
        //            case "female":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    ctx.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
        //            default:
        //                return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }
        //    }
        //}


        //public Employee GetById(int Id)
        //{
        //    using (EmployeeDBEntities ctx = new EmployeeDBEntities())
        //    {
        //        return ctx.Employees.FirstOrDefault(c => c.ID == Id);

        //    }
        //}

        public HttpResponseMessage GetById(int Id)
        {
            using (EmployeeDBEntities ctx = new EmployeeDBEntities())
            {
                var entity = ctx.Employees.FirstOrDefault(c => c.ID == Id);
                if (entity != null)
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, " Employee with id " + Id + " not found");
            }
        }

        public HttpResponseMessage Post(Employee employee)
        {
            try
            {
                using (EmployeeDBEntities ctx = new EmployeeDBEntities())
                {
                    ctx.Employees.Add(employee);
                    ctx.SaveChanges();

                    //return custom message
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                using (EmployeeDBEntities ctx = new EmployeeDBEntities())
                {
                    var entity = ctx.Employees.FirstOrDefault(c => c.ID == Id);
                    if (entity != null)
                    {
                        ctx.Employees.Remove(entity);
                        ctx.SaveChanges();
                        var msg =  Request.CreateResponse(HttpStatusCode.OK, entity);
                        msg.Headers.Location = new Uri(Request.RequestUri + entity.ID.ToString());
                        return msg; 
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int Id, Employee employee)
        {
            try
            {
                using (EmployeeDBEntities ctx = new EmployeeDBEntities())
                {
                    var entity = ctx.Employees.FirstOrDefault(c => c.ID == Id);
                    if (entity != null)
                    {
                        entity.FirstName = employee.FirstName;
                        entity.Gender = employee.Gender;
                        entity.LastName = employee.LastName;
                        entity.Salary = employee.Salary;
                        ctx.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
