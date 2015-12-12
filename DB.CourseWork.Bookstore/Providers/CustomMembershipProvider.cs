using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Collections.Specialized;
using System.Data.Entity;
using DB.CourseWork.Bookstore.Models;

namespace DB.CourseWork.Bookstore.Providers
{
    // TODO: change email to login, i.e. email or username
    public class CustomMembershipProvider : MembershipProvider
    {
        private DbContext context
        {
            get { return (DbContext)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(DbContext)); }
        }
        public MembershipUser CreateUser(string username, string email, string password)
        {
            MembershipUser membershipUser = GetUser(email, false);

            if (membershipUser != null)
                return null;

            var user = new User()
            {
                Username = username,
                Email = email,
                Password = Crypto.HashPassword(password)
            };

            context.Set<User>().Add(user);
            context.SaveChanges();
            membershipUser = GetUser(email, false);
            return membershipUser;
        }

        public override bool ValidateUser(string login, string password)
        {

            User user = context.Set<User>().FirstOrDefault(u => u.Email == login || u.Username == login);

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                return true;
            else
                return false;
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Email == login || u.Username == login);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Username,
                null, user.Email, null, null,
                false, false, DateTime.Now, DateTime.MinValue, 
                DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Email == email);

            if (user == null) return email;

            return user.Username;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
    }
}