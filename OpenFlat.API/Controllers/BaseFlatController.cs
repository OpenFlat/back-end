using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenFlat.API.Models;
using OpenFlat.API.Models.Dtos;

namespace OpenFlat.API.Controllers
{
    public abstract class BaseFlatController : ControllerBase, IDisposable
    {
        private FlatContext _db;
        protected FlatContext Db => _db ?? (_db = new FlatContext());

        private int _userId;
        protected int UserId => _userId != 0 ? _userId : (_userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))?.Value));

        private UserDto _userDto;
        protected UserDto UserDto => _userDto ?? (_userDto = _mapper.Map<UserDto>(Db.Users.FirstOrDefault(u => u.Id == UserId)));
        
        protected readonly IMapper _mapper;

        public BaseFlatController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
