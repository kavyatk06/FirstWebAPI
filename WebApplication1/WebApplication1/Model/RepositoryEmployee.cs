using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System;
using WebApplication1.Models;

namespace WebApplication1.Model
{
	public class RepositoryEmployee
	{
		private NorthwindContext _context;
		public RepositoryEmployee(NorthwindContext context)
		{
			_context = context;
		}
		public List<Employee> AllEmployees()
		{
			return _context.Employees.ToList();
		}
		public Employee FindEmpoyeeById(int id)
		{
			Employee employeeId = _context.Employees.Find(id);
			return employeeId;
		}
		public int AddEmployee(Employee newEmployee)
		{
			Employee? foundEmp = _context.Employees.Find(newEmployee.EmployeeId);
			if (foundEmp != null)
			{
				throw new Exception("Duplicate Id");
			}
			EntityState es = _context.Entry(newEmployee).State;
			Console.WriteLine($"EntityState B4Add:{es.GetDisplayName}");
			_context.Employees.Add(newEmployee);
			es = _context.Entry(newEmployee).State;
			Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");
			int result = _context.SaveChanges();
			es = _context.Entry(newEmployee).State;
			Console.WriteLine($"EntityState After saveChanges:{es.GetDisplayName()}");
			return result;
		}



		public int UpdateEmployee(Employee updatedEmployee)
		{
			int result = 0;
			EntityState es = _context.Entry(updatedEmployee).State;
			Console.WriteLine($"EntityState B4Add:{es.GetDisplayName}");
			_context.Entry(updatedEmployee).State = EntityState.Modified;
			es = _context.Entry(updatedEmployee).State;
			Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");
			result = _context.SaveChanges();
			es = _context.Entry(updatedEmployee).State;
			Console.WriteLine($"EntityState After saveChanges:{es.GetDisplayName()}");
			return result;

		}
		public int DeleteId(Employee emp)
		{


			_context.Employees.Remove(emp);
			_context.SaveChanges();





			return 1;
		}
	}
}
