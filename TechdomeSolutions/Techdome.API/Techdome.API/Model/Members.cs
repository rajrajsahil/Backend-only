using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techdome.API.Model
{
    public class Members
    {
        public class Member
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailId { get; set; }
            public string Password { get; set; }
            public Roles Role { get; set; }
        }
        public enum Roles
        {
            Admin,
            User
        }
    }
}
