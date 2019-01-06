using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenFlat.API.Models;
using OpenFlat.API.Models.Dtos;
using System.Linq;
using OpenFlat.API.Models.Entities;
using AutoMapper;

namespace OpenFlat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseFlatController
    {
        public UsersController(IMapper mapper) : base(mapper)
        {
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var users = Db.Users;
            if (!users.Any())
                return NotFound();
            var result = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            var user = Db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            var result = _mapper.Map<UserDto>(user);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UserDto value)
        {
            if (value == null)
                return BadRequest();
            if (Db.Users.Any(u => u.Email == value.Email || u.UserName == value.UserName))
                return Conflict();
            var user = _mapper.Map<User>(value);
            Db.Add<User>(user);
            Db.SaveChanges();
            var result = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(Get), result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto value)
        {
            if (id == 0 || value == null)
                return BadRequest();
            if (Db.Users.Any(u => u.Id != id && (u.Email == value.Email || u.UserName == value.UserName)))
                return Conflict();
            var user = _mapper.Map<User>(value);
            Db.Update<User>(user);
            Db.SaveChanges();
            var result = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(Get), result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            Db.Remove<User>(user);
            Db.SaveChanges();
            return Ok();
        }
    }
}
