using Company.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<UserToReturnDTO> users;
            if (string.IsNullOrEmpty(SearchInput))
            {
                users = _userManager.Users.Select(u => new UserToReturnDTO()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Roles = _userManager.GetRolesAsync(u).Result
                });
            }
            else
            {
                users = _userManager.Users.Select(u => new UserToReturnDTO()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Roles = _userManager.GetRolesAsync(u).Result
                }).Where(u => u.FirstName.ToLower().Contains(SearchInput.ToLower()));
            }

            return View(users);
        }
    }
    }
}
