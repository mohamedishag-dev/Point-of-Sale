using POS_Business.LogBAL;
using POS_Business.Security.Users;
using System;

namespace POS_Business.Security
{
    public static class Session
    {
        public static UserDto CurrentUser { get; private set; }
        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        internal static void Start(UserDto user) { CurrentUser = user; }
        public static void End() { CurrentUser = null; }

        public static bool Has(string permission)
        {
            return CurrentUser != null && CurrentUser.Role.Permissions.Find(p => p.PermissionName == permission) != null;
        }

        public static void RequireLogin()
        {
            if (CurrentUser == null) throw new UnauthorizedAccessException("سجّل الدخول أولاً.");
        }

        public static void Require(string permission)
        {
            RequireLogin();
            if (!CurrentUser.Role.Permissions.Exists(p => p.PermissionName == permission))
            {
                Logger.Warn("Permission denied: " + permission);
                throw new UnauthorizedAccessException("ليس لديك صلاحية تنفيذ هذه العملية.");
            }
        }


    }

}