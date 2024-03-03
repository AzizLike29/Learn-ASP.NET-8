using System.ComponentModel.DataAnnotations;

namespace EmployeesManagement.Models
{
	public class Contact
	{
		public string FullName { get; set; }

		[Required(ErrorMessage = "Please enter your email address")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string EmailAddress { get; set; }

		public string MessageSubject { get; set; }
		public string SendMessages { get; set; }
	}
}