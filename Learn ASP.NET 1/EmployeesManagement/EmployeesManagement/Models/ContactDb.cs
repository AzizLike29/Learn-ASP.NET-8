using System.Data;
using System.Data.SqlClient;

namespace EmployeesManagement.Models
{
	public class ContactDb
	{
		private readonly string connectionString = "Data Source=AZIZ;Initial Catalog=Employees;Integrated Security=True;TrustServerCertificate=True";

		public string SaveRecord(Contact contact)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand("contactField", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@FullName", contact.FullName);
						cmd.Parameters.AddWithValue("@EmailAddress", contact.EmailAddress);
						cmd.Parameters.AddWithValue("@MessageSubject", contact.MessageSubject);
						cmd.Parameters.AddWithValue("@SendMessages", contact.SendMessages);
						connection.Open();
						cmd.ExecuteNonQuery();
					}
				}
				return "Send Message Successfully!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}