using System;
using AngularMongoASP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularMongoASP.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
       // [Route("upload")]
        public IActionResult Upload( IFormFile file)
        {
             _fileService.UploadFile(file);
             return Ok();
        }
    }
}
