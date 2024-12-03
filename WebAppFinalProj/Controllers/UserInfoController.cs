using WebAppFinalProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly UserInfoContext _userInfoContext;

        public UserInfoController(UserInfoContext _userInfoContext)
        {
            this._userInfoContext = _userInfoContext;
        }

        [HttpGet] //get users
        [Route("GetUsers")]

        public List<UserInfo> GetUsers()
        {
            return _userInfoContext.Users.ToList();
        }

        // get one user and return first 5 entries in table if null
        /*
        [HttpGet]
        [Route("GetUser")] 

        public List<UserInfo> GetUserInfo(int id) 
        {
            if (_userInfoContext.Users.Where(x => x.ID == id).First() == null)
            {
                return _userInfoContext.Users.ToList();
            }
            else { return _userInfoContext.Users.FirstOrDefault();}
        }
        */
        [HttpPost] //add user
        [Route("AddUser")]

        public string AddUser(UserInfo userInfo)
        {
            string res = string.Empty;
            _userInfoContext.Users.Add(userInfo);
            _userInfoContext.SaveChanges();
            return "User added!";
        }


        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(UserInfo userInfo) 
        {
            _userInfoContext.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _userInfoContext.SaveChanges();

            return "User Updated!";
        }

        [HttpDelete]
        [Route("DeleteUser")]

        public string DeleteUser(UserInfo userInfo) 
        {
            _userInfoContext.Users.Remove(userInfo);
            _userInfoContext.SaveChanges();
            return "User deleted!";
        }
    }
}
