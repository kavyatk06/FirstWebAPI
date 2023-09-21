using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CollegeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CollegeController : ControllerBase
	{
		[HttpGet]
		public List<Student> GetStudents()
		{	
			List<Student> nplist=new List<Student>();
			Student np = new Student();
			np.Id = 1;
			np.StudentName = "std1";
			np.HouseName = "Lotus";
			return nplist;
			np.Id = 2;
			np.StudentName = "std2";
			np.HouseName = "Lilly";
			return nplist;


		}
	}
}
