using System;
using OpenFlat.API.Models.Enums;

namespace OpenFlat.API.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneOffice { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }
    }
}
