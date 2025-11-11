using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("User created");
        }
    }
}
