using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OpenFlat.API.Attributes.Base
{
    public abstract class BaseEntityStatedAttribute : ColumnAttribute
    {
        public EntityState State { get; set; }
        public BaseEntityStatedAttribute(string name, EntityState state) : base(name)
        {
            this.State = state;
        }
    }
}
