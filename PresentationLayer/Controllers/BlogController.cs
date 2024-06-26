using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Model.Setup.Blog;

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
                return Ok(await _bL_Blog.GetBlogs());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> CreateBlog([FromBody]BlogRequestModel requestModel)
        {
            try
            {
                int result = await _bL_Blog.CreateBlog(requestModel);

                return result > 0 ? StatusCode(201, "Saving Successful") : BadRequest("Saving Fail");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel,int id)
        {
            try
            {
                int result = await _bL_Blog.PatchBlog(requestModel,id);

                return result > 0 ? StatusCode(202, "Saving Successful") : BadRequest("Saving Fail");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                int result = await _bL_Blog.DeleteBlog(id);

                return result > 0 ? StatusCode(202, "Deleting Successful") : BadRequest("Deleting Fail");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}