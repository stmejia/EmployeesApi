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

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _context.Department.ToList();
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            var department = _context.Department.Find(id);
            return department;
        }
    }
}
