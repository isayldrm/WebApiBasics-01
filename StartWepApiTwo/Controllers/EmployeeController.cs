using StartWepApiTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartWepApiTwo.Controllers
{
    //Hızlı kullanım için kök dizin belirlendi.
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        static List<Employee> Employess = new List<Employee>()
        {
            new Employee() {Id=1, Name="Person-1"},
            new Employee() {Id=2, Name="Person-2"},
            new Employee() {Id=3, Name="Person-3"}
        };
        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return Employess;
        }

        
        //Route bu şekilde kısıtlar verebiliriz.(id değeri 1- 3 arası değer döndürür sadece)
        [Route("{id:int:range(1,3)}")]
        public Employee Get(int id)
        {
            return Employess.FirstOrDefault(e => e.Id == id);
        }

        [Route("{name:alpha:lastletter}")]
        public Employee Get(string name)
        {
            return Employess.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }
        [Route("{id}/tasks")]
        public IEnumerable<string> getEmployeeTasks(int id)
        {
            switch(id)
            {
                case 1:
                    return new List<string> { "Task 1-1", "Task 1-2", "Task 1-3" };
                case 2:
                    return new List<string> { "Task 2-1", "Task 2-2", "Task 2-3" };
                case 3:
                    return new List<string> { "Task 3-1", "Task 3-2", "Task 3-3" };
                default:
                    return null;
            }
        }

        //Yukarıda tanımlanan prefixi bu tanım için yok sayar(~).
        [Route("~/api/tasks")] 
        public IEnumerable<string> getTasks()
        {
            return new List<string> { "Task 1-1", "Task 1-2", "Task 1-3", "Task 2-1", "Task 2-2", "Task 2-3", "Task 3-1", "Task 3-2", "Task 3-3" };
        }
    }
}
