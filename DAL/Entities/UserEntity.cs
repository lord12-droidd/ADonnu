using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserEntity : IdentityUser
    {
        public virtual StudentEntity StudentProfile { get; set; }
    }
}
