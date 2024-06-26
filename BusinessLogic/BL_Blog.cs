using DataAccess;
using Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }
        public async Task<BlogListModel> GetBlogs()
        {
            try
            {
                return await _dA_Blog.GetBlogs();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
