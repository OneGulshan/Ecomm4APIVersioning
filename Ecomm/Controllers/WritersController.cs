using Ecomm.Data;
using Ecomm.Helper;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly Context _db;
        public WritersController(Context db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookWritter writer)
        {
            writer.ImageUrl = await FileHelper.UploadImage(writer.ImageFile);
            await _db.BookWritters.AddAsync(writer);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetWriters(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var writers = await (from writer in _db.BookWritters
                                 select new
                                 {
                                     Id = writer.Id,
                                     Name = writer.Name,
                                     ImageUrl = writer.ImageUrl

                                 }).ToListAsync();
            return Ok(writers.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> WriterDetails(int id)
        {
            var writer = await _db.BookWritters.Include(x => x.Books).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            return Ok(writer);
        }
    }
}