using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using DB.CourseWork.Bookstore.Models;
using System.Data.Entity;

namespace DB.CourseWork.Bookstore.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private DbContext context
        {
            get { return (DbContext)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(DbContext)); }
        }

        public override bool IsUserInRole(string login, string roleName)
        {

            string[] roles = GetRolesForUser(login);
            for (int i = 0; i < roles.Length; i++)
			{
                if (roleName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
			}
            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            string[] roles = {};
            User user = context.Set<User>().FirstOrDefault(u => u.Email == login || u.Username == login);
            if (user != null)
	        {
                roles = user.Roles.Select(role => role.Name).ToArray();
	        }
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            //var roleService = (IRoleService)System.Web.Mvc.DependencyResolver
            //    .Current.GetService(typeof(IRoleService));
            //var userService = (IUserService)System.Web.Mvc.DependencyResolver
            //    .Current.GetService(typeof(IUserService));
            var newRole = new Role() { Name = roleName };
            context.Set<Role>().Add(newRole);
            context.SaveChanges();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}