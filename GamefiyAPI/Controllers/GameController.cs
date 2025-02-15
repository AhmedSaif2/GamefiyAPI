using GamefiyAPI.Data;
using GamefiyAPI.Models;
using GamefiyAPI.Models.DTOs;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GamefiyAPI.Controllers
{
	[ApiController]
	[Route("api/games")]
	public class GameController : ControllerBase
	{
		IUnitOfWork _unitOfWork;
		public GameController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var game = _unitOfWork.Games.Get(game => id == game.Name, ["Publisher","Reviews"]);
			if (game == null)
			{
				return NotFound(); 
			}

			return Ok(game); 
		}
		[HttpGet("search")]
		public IActionResult Search([FromQuery] string name="", [FromQuery] string category = "")
		{
			var games = _unitOfWork.Games.Search(game=>game.Name.Contains(name)&&game.Category.Contains(category), ["Publisher", "Reviews"]);
			return Ok(games);
		}
		[HttpGet]
		public IActionResult GetAll([FromQuery]int pageNumber = 1, [FromQuery]int pageSize=10)
		{
			var games = _unitOfWork.Games.GetAll(["Publisher", "Reviews"], pageNumber,pageSize);
			return Ok(games);
		}
		[HttpPost("add")]
		public IActionResult Add([FromBody]CreateGameDto gameDto)
		{
			if (gameDto == null)
			{
				return BadRequest();
			}
			var publisher = _unitOfWork.Publishers.Get(gameDto.PublisherId);

			if (publisher == null)
			{
				return NotFound("Publisher Not Found");
			}
			var game = new Game
			{
				Id=Guid.NewGuid().ToString(),
				Description = gameDto.Description,
				Name = gameDto.Name,
				ReleaseDate = gameDto.ReleaseDate,
				Category = gameDto.Category,
				Publisher = publisher,
			};
			_unitOfWork.Games.Add(game);
			_unitOfWork.Save();
			return Ok("Game Was Added Successfully");
		}
		[HttpPut("{id}")]
		public IActionResult Update(string id, [FromBody] Dictionary<string, object> updates)
		{
			var existingGame = _unitOfWork.Games.Get(id);
			if (existingGame == null)
			{
				return NotFound("Game not found.");
			}

			// Loop over all properties of the Game class
			foreach (var key in updates.Keys)
			{
				var property = typeof(Game).GetProperty(key);
				if (property == null)
				{
					return BadRequest("Invalid Property");
				}
				if (property != null && property.CanWrite)
				{
					var newValue = Convert.ChangeType(updates[key], property.PropertyType);
					property.SetValue(existingGame, newValue);
				}
			}
			_unitOfWork.Games.Update(existingGame);
			_unitOfWork.Save();
			return Ok("Game Was Updated Successfully");
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			var game = _unitOfWork.Games.Get(id);
			if (game == null)
			{
				return NotFound();
			}
			_unitOfWork.Games.Delete(game);
			_unitOfWork.Save();
			return Ok("Game Was Deleted Successfully");
		}
		[HttpGet("reviews")]
		public IActionResult GetReviews(string id)
		{
			var game = _unitOfWork.Games.Get(game => game.Id == id, ["Reviews"]);
			if (game == null)
			{
				return NotFound();
			}
			return Ok(game.Reviews);
		}
	}
}
