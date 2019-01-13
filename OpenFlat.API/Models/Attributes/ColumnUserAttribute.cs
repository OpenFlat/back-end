using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenFlat.API.Models.Attributes.Base;

namespace OpenFlat.API.Models.Attributes
{
    public class ColumnUserAttribute : BaseEntityStatedAttribute
    {
        public ColumnUserAttribute(string name, EntityState state) : base(name, state)
        {
        }
    }
}
