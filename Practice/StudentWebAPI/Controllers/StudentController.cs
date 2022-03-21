using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentWebAPI.Interface;
using StudentWebAPI.Models;
using StudentWebAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService service;
        public StudentController()
        {
            service = new DbStudentService();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> SearchStudent(string searchText = null, string studentClass = null)
        {
            return service.SearchStudent(new StudentSearchCriteria
            {
                ClassName = studentClass,
                SearchText = searchText
            });
        }

        // GET api/<StudentController>/5
        [HttpGet("GetAllClass")]
        public List<string> GetClass()
        {
            return service.GetAllClasses();
        }

        // POST api/<StudentController>
        [HttpPost]
        public void CreateStudent([FromBody] Student value)
        {
            service.Add(value);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Update([FromBody] Student value)
        {
            service.Update(value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}
