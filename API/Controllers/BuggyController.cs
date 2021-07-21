using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest() 
        {
            var things = _context.Products.Find(42);

            if(things ==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError() 
        {
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() 
        {
            return NotFound(new ApiResponse(400));
        }
    }
}