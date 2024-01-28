using ExprementProject.DataBase;
using ExprementProject.Models;
using ExprementProject.Parshial;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExprementProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Communication : ControllerBase
    {
        ExDbContext _db;
        public Communication(ExDbContext db)
        {
            _db = db;
        }

        // GET: api/<ExprementController>
        [HttpGet]
        public List<UserInfo> GetExprement()
        {
            List<UserInfo> result = new List<UserInfo>();
            result = _db.userInfos.ToList();
            return result;
        }

        // POST api/<ExprementController>
        [HttpPost]
        public UserInfo PostAndEdit(UserInfo EObject)
        {
            if (EObject.Id>0)
            {
                 _db.userInfos.Update(EObject);
                _db.SaveChanges();
                UserInfo Data = _db.userInfos.Find(EObject.Id);
                EObject.Message = "Update Successfull";
            }
            else
            {
                _db.userInfos.Add(EObject);
                _db.SaveChanges();
                EObject.Message = "Post Success";
            }
            return EObject;
        }


        // DELETE api/<ExprementController>/5
        [HttpDelete]
        public UserInfo RemoveExprement(int Id)
        {
            UserInfo EDeletObje =new UserInfo();
            EDeletObje = _db.userInfos.Find(Id);
            _db.userInfos.Remove(EDeletObje);
            _db.SaveChanges();
            return EDeletObje;
        }


        [HttpPost]
        public IActionResult UserLogin(LoginUser loginUser)
        {
            var Object = _db.userInfos.FirstOrDefault(x=>x.Email == loginUser.Email && x.Password==loginUser.Password);
            return Ok(Object);
        }
        [HttpGet]
        public IActionResult GetUser(int id)
        {

            var result = _db.userInfos.FirstOrDefault(x=>x.Id==id);
            return Ok(result);
        }



    }
}
