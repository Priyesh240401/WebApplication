using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Sample array of student names
        private readonly string[] _studentNames = { "Priyesh", "Prashant", "Rachit", "Puskar" };

        // GET: api/student
        [HttpGet]
        public ActionResult<string[]> GetAllStudents()
        {
            return Ok(_studentNames);
        }

        // GET: api/student/sample
        [HttpGet("sample")]
        public ActionResult<string[]> GetSampleStudents()
        {
            // Print out the first two student names from the array
            string[] sampleStudents = new string[2];
            for (int i = 0; i < 2 && i < _studentNames.Length; i++)
            {
                sampleStudents[i] = _studentNames[i];
            }
            return Ok(sampleStudents);
        }
    }
}
