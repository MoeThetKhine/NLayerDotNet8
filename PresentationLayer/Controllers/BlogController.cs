using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                return  Ok(await _bL_Blog.GetBlogs());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}