using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApiClientConsole
{
	internal class EmployeeAPIClient
	{
		static Uri uri = new Uri("http://localhost:5139/");
		public static async Task GetAlListlEmployee()

		{

			using (var client = new HttpClient())

			{

				client.BaseAddress = uri;

				List<EmpViewModel> employees = new List<EmpViewModel>();

				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync("GetAllEmployees");

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)

				{



					String json = await response.Content.ReadAsStringAsync();

					employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);

					foreach (EmpViewModel emp in employees)

					{

						await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City},{emp.ReportsTo}");

					}


				}

			}



		}
		public static async Task AddNewEmployee()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = uri;
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				EmpViewModel employee = new EmpViewModel()
				{
					FirstName = "WILLAIAM",
					LastName = "john",
					City = "india",
					BirthDate = new DateTime(1980, 01, 01),
					HireDate = new DateTime(2000, 01, 01),
					Title = "Manager"
				};
				var mycontent = JsonConvert.SerializeObject(employee);
				var buffer = Encoding.UTF8.GetBytes(mycontent);
				var byteContent = new ByteArrayContent(buffer);
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				HttpResponseMessage response = await client.PostAsync("AddEmployee", byteContent);
				response.EnsureSuccessStatusCode();
				if (response.IsSuccessStatusCode)
				{
					await Console.Out.WriteLineAsync(response.StatusCode.ToString());
				}
			}
		}
		public static async Task UpdateEmployee()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = uri;
				client.DefaultRequestHeaders.Accept
					.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				EmpViewModel emp = new EmpViewModel();
				emp.EmpId = 12;
				emp.FirstName = "Reena";
				emp.LastName = "Ross";
				emp.City = "Uk";
				emp.BirthDate = new DateTime(1992, 01, 01);
				emp.HireDate = new DateTime(2018, 04, 01);
				emp.Title = "Manager";
				var myContent = JsonConvert.SerializeObject(emp);
				var buffer = Encoding.UTF8.GetBytes(myContent);
				var byteContent = new ByteArrayContent(buffer);
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				//httpPUT
				HttpResponseMessage response = await client.PutAsync("UpdateEmployee", byteContent);
				response.EnsureSuccessStatusCode();





			}
		}
		public static async Task DeleteEmployee()
		{

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				Console.WriteLine("Enter the id to be Deleted");
				string temp = Console.ReadLine();
				int id = int.Parse(temp);

				var json = JsonConvert.SerializeObject(id);
				var bytes = Encoding.UTF8.GetBytes(json);
				var byteHttpClient = new ByteArrayContent(bytes);
				byteHttpClient.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
				var Uri = uri + $"DeleteEmployee?id={id}";
				HttpResponseMessage response = await client.DeleteAsync(Uri);
				response.EnsureSuccessStatusCode();
				if (response.IsSuccessStatusCode)
				{
					await Console.Out.WriteLineAsync(response.StatusCode.ToString());
				}


			}
		}
	}
}
