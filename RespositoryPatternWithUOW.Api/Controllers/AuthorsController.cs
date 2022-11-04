using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            return Ok( await _unitOfWork.Authors.GetByAllAsync());
        }
        [HttpGet("GetById")]
        public async Task< IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(id));
        }
    }
}
