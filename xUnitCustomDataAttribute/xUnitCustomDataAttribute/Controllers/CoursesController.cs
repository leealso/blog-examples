using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheoryTestCustomDataAttribute.Models;
using TheoryTestCustomDataAttribute.Services;

namespace TheoryTestCustomDataAttribute.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent([FromBody]Student student)
        {
            var response = _service.Enroll(student);

            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult EnrollGroup([FromBody]List<Student> group)
        {
            var response = _service.Enroll(group);

            return Ok(response);
        }
    }
}
