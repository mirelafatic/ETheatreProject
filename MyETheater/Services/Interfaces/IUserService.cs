using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheater.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Login(UserModel userData);
        bool Register(UserModel user);
    }
}
