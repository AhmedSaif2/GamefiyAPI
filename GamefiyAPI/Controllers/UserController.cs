using GamefiyAPI.Models;
using GamefiyAPI.Models.DTOs;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamefiyAPI.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : Controller
	{
		IUnitOfWork _unitOfWork;
		public UserController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var user = _unitOfWork.Users.Get(user => user.Id == id, ["Reviews"]);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}
		[HttpGet]
		public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var games = _unitOfWork.Users.GetAll(pageNumber, pageSize);
			return Ok(games);
		}
		[HttpPost("add")]
		public IActionResult Add([FromBody] CreateUserDto newUser)
		{
			if (newUser == null)
			{
				return BadRequest();
			}
			var user = new User
			{
				Id = Guid.NewGuid().ToString(),
				FirstName = newUser.FirstName,
				LastName = newUser.LastName,
				Email = newUser.Email,
				Country = newUser.Country,
				Address = newUser.Address,
				PhoneNumber = newUser.PhoneNumber
			};
			_unitOfWork.Users.Add(user);
			_unitOfWork.Save();
			return CreatedAtAction("Get", new { id = user.Id }, user);
		}
		[HttpGet("reviews")]
		public IActionResult GetReviews(string id)
		{
			var user = _unitOfWork.Users.Get(user => user.Id == id, ["Reviews"]);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user.Reviews);
		}

	}
}
