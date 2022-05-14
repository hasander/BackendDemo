using BackendDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDemo.Data.Context.Seed
{
    public static class UserSeeds
    {
        public static void AddUserSeed(this ModelBuilder builder)
        {
            builder.Entity<User>()
              .HasData(new User
              {
                  ID = 1,
                  FirstName = "Admin",
                  LastName = "Admin",
                  Adress = "Turkey",
                  PhoneNumber = "555555555555",
                  profilePicture = ""
              });
        }
    }
}
