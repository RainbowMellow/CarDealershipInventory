﻿using CarDealershipInventory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipInventory.Core.ApplicationServices
{
    public interface IUserService
    {
        public User GetUserFromLoginInput(LoginInputModel model);
    }
}
