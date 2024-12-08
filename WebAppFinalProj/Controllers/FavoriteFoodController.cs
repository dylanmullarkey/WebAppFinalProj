using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppFinalProj.Models;

namespace WebAppFinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFoodController : ControllerBase
    {
        private readonly UserInfoContext _userInfoContext;

        public FavoriteFoodController(UserInfoContext _userInfoContext)
        {
            this._userInfoContext = _userInfoContext;
        }

        [HttpGet] //get users
        [Route("GetFoodies")]

        public List<FavoriteFood> GetUsers()
        {
            return _userInfoContext.FavoriteFoods.ToList();
        }

        // get one user and return first 5 entries in table if null

        [HttpGet]
        [Route("GetFirstFiveFoodies")]
        public List<FavoriteFood> GetUserInfo(int id)
        {
            var user = _userInfoContext.FavoriteFoods.FirstOrDefault(x => x.ID == id);
            if (user == null)
            {
                return _userInfoContext.FavoriteFoods.ToList();
            }
            else
            {
                return new List<FavoriteFood> { user };
            }
        }


        [HttpPost] //add user
        [Route("AddFoodie")]

        public string AddUser(FavoriteFood favoriteFood)
        {
            string res = string.Empty;
            _userInfoContext.FavoriteFoods.Add(favoriteFood);
            _userInfoContext.SaveChanges();
            return "User added!";
        }


        [HttpPut]
        [Route("UpdateFoodie")]

        public string UpdateUser(FavoriteFood favoriteFood)
        {
            _userInfoContext.Entry(favoriteFood).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _userInfoContext.SaveChanges();

            return "User Updated!";
        }

        [HttpDelete]
        [Route("DeleteFoodie")]

        public string DeleteUser(FavoriteFood favoriteFood)
        {
            _userInfoContext.FavoriteFoods.Remove(favoriteFood);
            _userInfoContext.SaveChanges();
            return "User deleted!";
        }
    }
}
