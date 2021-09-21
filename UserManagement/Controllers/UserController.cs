using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain;
using UserManagement.Service;

namespace UserManagement.Controllers
{

    [ApiController]
    [Route("Taazaa/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository;
        IUserProfileRepository userProfileRepository;

        public UserController(IUserRepository _userRepository, IUserProfileRepository _userProfileRepository)
        {
            userRepository = _userRepository;
            userProfileRepository = _userProfileRepository;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult createAccount(UserDTO model)
        {
            /*  User user = new User();
             user.ID = model.Id; */
            User user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                userProfile = new UserProfile
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                }
            };
            userRepository.InsertUser(user);
            return Ok("Created successfully!!");
        }
    }
}