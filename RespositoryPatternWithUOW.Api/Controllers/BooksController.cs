using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Core.Consts;
using RespositoryPatternWithUOW.Core.Dtos;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Books.GetByAllAsync());
        }
        [HttpGet("GetAllWithAuthors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Books.FindAllAsync(b => b.Title.Contains("new"), new[] { nameof(Author) }));
        }
        [HttpGet("GetAllWithTakeSkipOrderBy")]
        public async Task<IActionResult> GetAllWithTakeSkipOrderBy()
        {
            return Ok(await _unitOfWork.Books.FindAllAsync(b => b.Title.Contains("a"), 5, 3, b => b.Id,OrdesrBy.Descending));
        }
        [HttpGet("GetById")]
        public async Task< IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Books.GetByIdAsync(id));
        }
        [HttpGet("GetByTitle")]
        public async  Task<IActionResult> GetByNameAsync(string title )
        {
            return Ok(await _unitOfWork.Books.Find(b => b.Title == title, new[] { nameof(Author) })); 
        }
        [HttpPost("AddOne")]
        public async Task<IActionResult> AddOne(BookDto dto)

        {
            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId
            };
            var model = await _unitOfWork.Books.Add(book);
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
