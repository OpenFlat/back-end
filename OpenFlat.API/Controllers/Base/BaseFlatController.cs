using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenFlat.API.Models;
using OpenFlat.API.Models.Dtos;
using OpenFlat.API.Models.Entities;

namespace OpenFlat.API.Controllers.Base
{
    public abstract class BaseFlatController : ControllerBase, IDisposable
    {
        private FlatContext _db;
        protected FlatContext Db => _db ?? (_db = new FlatContext(AuthorizedUserId));

        private int _authorizedUserId;
        protected int AuthorizedUserId => _authorizedUserId != 0 ? _authorizedUserId : (_authorizedUserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))?.Value));

        private User _authorizedUser;
        protected User AuthorizedUser => _authorizedUser ?? (_authorizedUser = Db.Users.FirstOrDefault(u => u.Id == AuthorizedUserId));
        
        protected readonly IMapper _mapper;

        public BaseFlatController(IMapper mapper)
        {
            _mapper = mapper;
            _authorizedUserId = 0;
            _authorizedUser = null;
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
