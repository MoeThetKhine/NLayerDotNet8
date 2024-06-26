using DbService;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Model.Setup.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DA_Blog
    {
        private readonly AppDbContext _appDbContext;

        public DA_Blog(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<BlogListModel> GetBlogs()
        {
            try
            {
                var lst = await _appDbContext.Blogs
                    .AsNoTracking()
                    .OrderByDescending(x=> x.BlogId)
                    .ToListAsync();

                BlogListModel responseModel = new()
                {
                   DataLst = lst.Select(x => x.Change()).ToList()
                };
                 return responseModel;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int>CreateBlog(BlogRequestModel requestModel)
        {
            try
            {
                await _appDbContext.Blogs.AddAsync(requestModel.Change());
                return await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> PatchBlog(BlogRequestModel requestModel,int id)
        {
            try
            {
                var item = await _appDbContext.Blogs
                     .AsNoTracking()
                     .FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new Exception("No data found");

                if (!string.IsNullOrEmpty(requestModel.BlogTitle))
                {
                    item.BlogTitle = requestModel.BlogTitle;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
                {
                    item.BlogAuthor = requestModel.BlogAuthor;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogContent))
                {
                    item.BlogContent = requestModel.BlogContent;
                }
                _appDbContext.Entry(item).State = EntityState.Modified;
                return await _appDbContext.SaveChangesAsync();  
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int>DeleteBlog(int id)
        {
            try
            {
                var item = await _appDbContext.Blogs
                      .AsNoTracking()
                      .FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new Exception("No data found");
                _appDbContext.Remove(item);
                return await _appDbContext.SaveChangesAsync();  
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
