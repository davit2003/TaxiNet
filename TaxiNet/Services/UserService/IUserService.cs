using System;
using System.Collections.Generic;
using System.Text;
using TaxiNet.DataLayer.DataModels;

namespace TaxiNet.Services.UserService
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
