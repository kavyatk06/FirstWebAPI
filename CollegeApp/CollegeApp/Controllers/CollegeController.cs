using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace CollegeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CollegeController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<Student> GetStudents()
		{
			return RepositoryStudent.s;






		}
		[HttpGet("id")]
		public ActionResult<Student> GetStudentById(int id)
		{
			var student = RepositoryStudent.s.FirstOrDefault(s => s.Id == id);

			if (student == null)
			{
				return NotFound(); // Return a 404 Not Found response if the student is not found.
			}

			return student;
		}
		[HttpGet("name")]
		public ActionResult<Student> GetStudentByName(string name)
		{
			var student = RepositoryStudent.s.FirstOrDefault(s => s.StudentName == name);
			return student;
		}
		[HttpDelete("id")]
		public string  DeleteStudentById(int id)
		{
			var student = RepositoryStudent.s.FirstOrDefault(s => s.Id == id);
			RepositoryStudent.s.Remove(student);
			return "deleted";
		}
	}
	
}
