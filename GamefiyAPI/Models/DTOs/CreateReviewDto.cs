namespace GamefiyAPI.Models.DTOs
{
	public class CreateReviewDto
	{
		public string GameId { get; set; }
		public string UserId { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
	}
}
