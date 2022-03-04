using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EmployeeController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de empleados registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employee.ToList();
        }

        /// <summary>
        /// Obtiene un empleado especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = _context.Employee.Find(id);
            return employee;
        }

        /// <summary>
        /// Insertamos un empleado
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            try
            {
                _context.Employee.Add(employee);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modificamos un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Employee employee)
        {
            if (employee.EmployeeId == id)
            {
                _context.Employee.Update(employee);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Eliminamos un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Put(int id)
        {
            var employee = _context.Employee.Find(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
