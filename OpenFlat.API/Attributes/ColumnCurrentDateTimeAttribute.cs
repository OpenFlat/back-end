using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenFlat.API.Attributes.Base;

namespace OpenFlat.API.Attributes
{
    public class ColumnCurrentDateTimeAttribute : BaseEntityStatedAttribute
    {
        public ColumnCurrentDateTimeAttribute(string name, EntityState state) : base(name, state)
        {
        }
    }
}
