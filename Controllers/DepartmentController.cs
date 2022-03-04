using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDBContext _context;

        public DepartmentController(IConfiguration configuration, ApplicationDBContext context)
        {
            _configuration = configuration;
            this._context = context;
        }

        /// <summary>
        /// Obtiene el listado de departamentos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _context.Department.ToList();
        }

        /// <summary>
        /// Obtiene un departamento especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            var department = _context.Department.Find(id);
            return department;
        }

        /// <summary>
        /// Insertamos un departamento
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Department department)
        {
            try
            {
                _context.Department.Add(department);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modificamos un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Department department)
        {
            if (department.DepartmentId == id)
            {
                _context.Department.Update(department);
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
            var department = _context.Department.Find(id);
            if (department != null)
            {
                _context.Department.Remove(department);
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
