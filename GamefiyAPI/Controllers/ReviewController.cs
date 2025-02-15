using GamefiyAPI.Models;
using GamefiyAPI.Models.DTOs;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamefiyAPI.Controllers
{
	[ApiController]
	[Route("api/reviews")]
	public class ReviewController : Controller
	{
		IUnitOfWork _unitOfWork;
		public ReviewController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var review = _unitOfWork.Reviews.Get(id);
			if (review == null)
			{
				return NotFound();
			}
			return Ok(review);
		}
		[HttpGet]
		public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var games = _unitOfWork.Reviews.GetAll(["user", "game"],pageNumber, pageSize);
			return Ok(games);
		}
		[HttpPost("add")]
		public IActionResult Add([FromBody] CreateReviewDto newReview)
		{
			if (newReview == null)
			{
				return BadRequest();
			}
			if (_unitOfWork.Users.Get(newReview.UserId) == null)
			{
				return NotFound("User not found");
			}
			if (_unitOfWork.Games.Get(newReview.GameId) == null)
			{
				return NotFound("Game not found");
			}
			var review = new Review
			{
				Id = Guid.NewGuid().ToString(),
				UserId = newReview.UserId,
				GameId = newReview.GameId,
				Content = newReview.Content,
				Rating = newReview.Rating
			};
			_unitOfWork.Reviews.Add(review);
			_unitOfWork.Save();
			return CreatedAtAction("Get", new { id = review.Id }, review);
		}
	}
}
