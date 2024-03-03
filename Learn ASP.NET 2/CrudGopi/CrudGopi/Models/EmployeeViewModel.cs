using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudGopi.Models
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }

		[DisplayName("FirstName")]
		public string FirstName { get; set; }

		[DisplayName("LastName")]
		public string LastName { get; set; }

		[DisplayName("DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }
		public double Salary { get; set; }

		[DisplayName("Name")]
		public string FullName
		{
			get { return FirstName + "" + LastName; }
		}
	}
}
