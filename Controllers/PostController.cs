using ExprementProject.DataBase;
using ExprementProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace ExprementProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly ExDbContext _context;
        public PostController(ExDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  List<Post> GetPostData(int Id)
        {
            var Data = _context.posts.Where(x=>x.UserId==Id).ToList();
            return Data;
        }


        [HttpPost]
        public Post PostUserpost(Post posts)
        {
            try
            {
                var data = _context.posts.Add(posts);
                _context.SaveChanges();
                return posts;
            }
            catch (Exception ex)
            {
                return new Post();
            }
        }

        [HttpDelete]
        public Post PostDeleted(int Id)
        {
            Post EDeletObje = new Post();
            EDeletObje = _context.posts.Find(Id);
            if (EDeletObje!=null)
            {
                _context.posts.Remove(EDeletObje);
                _context.SaveChanges();
            }
            return EDeletObje;
        }

        [HttpPost]

        public Post UpdatePost(Post post)
        {
            _context.posts.Update(post);
            _context.SaveChanges();
            return post;
        }




        [HttpPost,DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage()
        {
            FileTabel oTempFile = new FileTabel();
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = Request.Form.Files[0];
                if (file == null)
                {
                    throw new Exception("File Not Found");
                }
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    if(file.Length > 0)
                    {
                        oTempFile.Id = 0;
                        oTempFile.Image = ms.ToArray();
                        var data = _context.FileTabel.Add(oTempFile);
                        _context.SaveChanges();
                    }
                }
                return Ok(oTempFile);

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpGet]
        public List<FileTabel> GetFileData()
        {
            var Data = _context.FileTabel.Where(x => x.Id != 0).OrderByDescending(x=>x.Id).ToList();
            return Data;
        }



    }
}
