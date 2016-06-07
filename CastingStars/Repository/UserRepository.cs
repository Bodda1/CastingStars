using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastingStars.Models;

namespace CastingStars.Repository
{
    public class UserRepository
    {
        public User GetUserByEmail (string Email)
        {
            User user = new User();
            return user;
        }


        public bool isValidPassword (string Email, string Password)
        {
            return true;
        }


        public void UpdateLastLogin (User user)
        {

        }
    }
}