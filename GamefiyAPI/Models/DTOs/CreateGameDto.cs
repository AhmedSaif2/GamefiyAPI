namespace GamefiyAPI.Models.DTOs
{
	public class CreateGameDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string PublisherId { get; set; }
	}
}
