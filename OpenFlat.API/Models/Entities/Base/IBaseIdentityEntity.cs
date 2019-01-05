using System;

namespace OpenFlat.API.Models.Entities.Base
{
    public interface IBaseIdentityEntity: IBaseEntity
    {
         int Id { get; set; }
    }
}
