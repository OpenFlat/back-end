using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenFlat.API.Models;

namespace OpenFlat.API.Controllers
{
    public abstract class BaseFlatController : ControllerBase, IDisposable
    {
        private FlatContext _db;
        protected FlatContext Db => _db ?? (_db = new FlatContext());
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
