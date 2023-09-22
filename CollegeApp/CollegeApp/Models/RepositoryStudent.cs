namespace CollegeApp.Models
{
	public class RepositoryStudent
	{
		public static List<Student> s { get; set; }=new List<Student>()
		
            {
	        new Student
	        {
		           Id = 1,
		           StudentName = "std1",
		           HouseName = "Lotus"
	        },
	        new Student
	        {
		           Id = 2,
		           StudentName = "std2",
		           HouseName = "Rose"
	         }
            };
	}
}
