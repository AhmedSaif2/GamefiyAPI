
using System.Text.Json.Serialization;

namespace GamefiyAPI.Models
{
	public class Publisher
	{
		public string Id { get; set; }
		public string Name { get; set; }
		[JsonIgnore]
		public List<Game>?Games { get; set; }
	}
}
