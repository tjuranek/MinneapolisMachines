using MinneapolisMachines.App.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinneapolisMachines.App.Models.Admin
{
    public class UserRoleViewModel
    {
        public User SelectedUser { get; set; }

        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }
    }
}