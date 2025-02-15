using GamefiyAPI.Models;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamefiyAPI.Controllers
{
	[ApiController]
	[Route("api/publishers")]
	public class PublisherController : ControllerBase
	{
		IUnitOfWork _unitOfWork;
		public PublisherController(IUnitOfWork unitOfWork) 
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var publisher = _unitOfWork.Publishers.Get(id);
			if (publisher == null)
			{
				return NotFound();
			}
			return Ok(publisher);
		}
		[HttpGet]
		public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var games = _unitOfWork.Publishers.GetAll(pageNumber, pageSize);
			return Ok(games);
		}
		[HttpPost("add")]
		public IActionResult Add([FromBody] string name)
		{
			if (name == null)
			{
				return BadRequest();
			}
			var publisher = new Publisher
			{
				Id = Guid.NewGuid().ToString(),
				Name = name
			};
			_unitOfWork.Publishers.Add(publisher);
			_unitOfWork.Save();
			return Ok("Publisher Was Added Successfully");
		}
		[HttpPut("{id}")]
		public IActionResult Update(string id, [FromBody] string name)
		{
			if (name == null)
			{
				return BadRequest();
			}
			var publisher = _unitOfWork.Publishers.Get(id);
			if (publisher == null)
			{
				return NotFound();
			}
			publisher.Name = name;
			_unitOfWork.Publishers.Update(publisher);
			_unitOfWork.Save();
			return Ok("Publisher Was Updated Successfully");
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			var publisher = _unitOfWork.Publishers.Get(id);
			if (publisher == null)
			{
				return NotFound();
			}
			_unitOfWork.Publishers.Delete(publisher);
			_unitOfWork.Save();
			return Ok("Publisher Was Deleted Successfully");
		}
	}
}
