using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		static RepositoryEmployee _repositoryEmployee;
		public EmployeeController(RepositoryEmployee repository)
		{
			_repositoryEmployee = repository;
		}
		[HttpGet("/ListAllEmployees")]
		public List<Employee> ListAllEmployees()
		{
			List<Employee> employeesList = _repositoryEmployee.AllEmployees();
			return employeesList;
		}
		[HttpGet("/FindEmployee")]
		public Employee FindEmployee(int id)
		{
			Employee employeeById = _repositoryEmployee.FindEmpoyeeById(id);
			return employeeById;
		}
		[HttpPost("/AddEmployee")]
		public int AddEmployee(EmpViewModel newEmployee)
		{
			Employee employee = new Employee();
			employee.FirstName = newEmployee.FirstName;
			employee.LastName = newEmployee.LastName;
			employee.BirthDate = newEmployee.BirthDate;
			employee.HireDate = newEmployee.HireDate;
			employee.Title = newEmployee.Title;
			employee.City = newEmployee.City;
			employee.ReportsTo = newEmployee.ReportsTo> 0 ? newEmployee.ReportsTo : null;
			// employee.EmployeeId
			int res = _repositoryEmployee.AddEmployee(employee);
			return res ;

		}
		[HttpPut("/UpdateEmployee")]
		public int EditEmployee( EmpViewModel newEmployee)
		{
			Employee employee = new Employee();
			employee.EmployeeId= newEmployee.EmpId;
			employee.FirstName = newEmployee.FirstName;
			employee.LastName = newEmployee.LastName;
			employee.BirthDate = newEmployee.BirthDate;
			employee.HireDate = newEmployee.HireDate;
			employee.Title = newEmployee.Title;
			employee.City = newEmployee.City;// Ensure the ID in the URL matches the EmployeeId
			int savedEmployee = _repositoryEmployee.UpdateEmployee(employee);
			return savedEmployee;
		}


		[HttpDelete("/DeleteEmployee")]
		public int DeleteEmployee(int id)
		{


			Employee employee = _repositoryEmployee.FindEmpoyeeById(id);
			if (employee != null)
			{
				return _repositoryEmployee.DeleteId(employee); ;
			}
		
			return 0;
		}

		
		[HttpGet("/GetAllEmployee")]
		public IEnumerable<EmpViewModel> GetAllEmployee()
		{
			List<Employee> employees = _repositoryEmployee.AllEmployees();
			var empList = (
				from emp in employees
				select new EmpViewModel()
				{
					EmpId = emp.EmployeeId,
					FirstName = emp.FirstName,
					LastName = emp.LastName,
					BirthDate = (DateTime)emp.BirthDate,
					HireDate = (DateTime)emp.HireDate,
					Title = emp.Title,
					City = emp.City,
					ReportsTo =emp.ReportsTo
				}).ToList();
			return empList;
		}
	}
}
