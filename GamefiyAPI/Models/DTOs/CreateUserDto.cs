using System.ComponentModel.DataAnnotations;

namespace GamefiyAPI.Models.DTOs
{
	public class CreateUserDto
	{
		[Required, MaxLength(250)]
		public string FirstName { get; set; }
		[Required, MaxLength(250)]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		public string Country { get; set; }
		public string Address { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
	}
}
