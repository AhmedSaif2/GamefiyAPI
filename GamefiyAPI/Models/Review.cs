using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GamefiyAPI.Models
{
	public class Review
	{
		[JsonIgnore]
		public string Id { get; set; }
		[Required,JsonIgnore]
		public string GameId { get; set; }
		[JsonIgnore]
		public Game Game { get; set; }
		[Required,JsonIgnore]
		public string UserId { get; set; }
		[JsonIgnore]
		public User User{ get; set; }
		[Required,MaxLength(1000)]
		public string Content { get; set; }
		[Required]
		public int Rating { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
