using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static GamefiyAPI.Constants.Enums;

namespace GamefiyAPI.Models
{
	public class Game
	{
		public string Id { get; set; }
		[Required,MaxLength(255)]
		public string Name { get; set; }
		[Required,MaxLength(1000)]
		public string Description { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Category{ get; set; } 
		public Publisher Publisher{ get; set; }
		public List<Review> Reviews { get; } = [];
	}
	
}
