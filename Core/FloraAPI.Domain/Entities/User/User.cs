﻿using Microsoft.AspNetCore.Identity;

namespace FloraAPI.Domain.Entities.User
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
