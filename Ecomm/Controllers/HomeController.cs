using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/home")] // Querystring api versioning
    //[Route("api/v{version:apiVersion}/home")] // UrlPath-Api Versioning
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        static List<BookWritter> Writers = new List<BookWritter>
        {
            new BookWritter(){Id=1,Name="Gulshan"},
            new BookWritter(){Id=2,Name="Ramesh"}
        };
        [HttpGet]
        public IEnumerable<BookWritter> Get()
        {
            return Writers;
        }
    }
}
