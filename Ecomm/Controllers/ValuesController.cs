using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Controllers
{
    [ApiVersion("2.0")]
    //[Route("api/home")]
    //[Route("api/v{version:apiVersion}/home")]
    [Route("api/home")] // MediaType Versioning is checked by Postman using header
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<BookWritter> Writers = new List<BookWritter>
        {
            new BookWritter(){Id=1,Name="Gulshan",Gender="Male"},
            new BookWritter(){Id=2,Name="Ramesh",Gender="Male"}
        };
        [HttpGet]
        public IEnumerable<BookWritter> Get()
        {
            return Writers;
        }
    }
}
