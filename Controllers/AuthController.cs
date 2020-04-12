using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthExample.Models;
using AuthExample.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthExample.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DatabaseContext _context;
        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        // Incoming Params: {fullname: "", email: "", password: ""}
        // Because this is diffent from our User object (password is hashedPassowrd), we create a view model

        [HttpPost("signup")]
        public async Task<ActionResult> SignUpUser(NewUser newUser)
        {
            // validating the user data
            if (newUser.Password.Length < 7)
            {
                return BadRequest("Password must be longer than 7 characters");
            }

            var doesUserExist = await _context.Users.AnyAsync(user => user.Email.ToLower() == newUser.Email.ToLower());
            if (doesUserExist)
            {
                return BadRequest("User already exists with that email");
            }

            // hashing the password
            var user = new User
            {
                Email = newUser.Email,
                FullName = newUser.FullName
            };

            var hashed = new PasswordHasher<User>().HashPassword(user, newUser.Password);
            user.HashedPassword = hashed;
            // storing the user data
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // generating a JWT 
            return Ok(user);
        }
    }
}