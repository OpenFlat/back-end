using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenFlat.API.Models;
using OpenFlat.API.Models.Dtos;
using System.Linq;
using OpenFlat.API.Models.Entities;

namespace OpenFlat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseFlatController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            using (var db = new FlatContext())
            {
                return db.Users.Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Password = u.Password,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    PhoneMobile = u.PhoneMobile,
                    PhoneHome = u.PhoneHome,
                    PhoneOffice = u.PhoneOffice,
                    BirthDate = u.BirthDate,
                    Gender = u.Gender
                }).ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            using (var db = new FlatContext())
            {
                return db.Users.Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Password = u.Password,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    PhoneMobile = u.PhoneMobile,
                    PhoneHome = u.PhoneHome,
                    PhoneOffice = u.PhoneOffice,
                    BirthDate = u.BirthDate,
                    Gender = u.Gender
                }).FirstOrDefault(u => u.Id == id);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] UserDto value)
        {
            using (var db = new FlatContext())
            {
                var user = new User()
                {
                    Id = value.Id,
                    UserName = value.UserName,
                    Password = value.Password,
                    Name = value.Name,
                    Surname = value.Surname,
                    Email = value.Email,
                    PhoneMobile = value.PhoneMobile,
                    PhoneHome = value.PhoneHome,
                    PhoneOffice = value.PhoneOffice,
                    BirthDate = value.BirthDate,
                    Gender = value.Gender
                };
                db.Add<User>(user);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto value)
        {
            using (var db = new FlatContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                user.Id = value.Id;
                user.UserName = value.UserName;
                user.Password = value.Password;
                user.Name = value.Name;
                user.Surname = value.Surname;
                user.Email = value.Email;
                user.PhoneMobile = value.PhoneMobile;
                user.PhoneHome = value.PhoneHome;
                user.PhoneOffice = value.PhoneOffice;
                user.BirthDate = value.BirthDate;
                user.Gender = value.Gender;
                db.Update<User>(user);
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new FlatContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                db.Remove<User>(user);
                db.SaveChanges();
            }
        }
    }
}
