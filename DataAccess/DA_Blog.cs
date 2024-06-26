using DbService;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Model.Blog;
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
    }
}
