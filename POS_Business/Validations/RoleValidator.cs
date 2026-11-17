using POS_DataAccess.Models;

namespace POS_Business.Validations
{
    public static class RoleValidator
    {
        public static ValidationResult Validate(Role role)
        {
            var result = new ValidationResult();

            if (role == null) { result.Add("بيانات المستخدم غير موجودة"); return result; }

            if (string.IsNullOrWhiteSpace(role.RoleName))
                result.Add("الاسم مطلوب");

            if (role.Permissions == null || role.Permissions.Count == 0)
                result.Add("الدور لا تحتوي على صلاحيات");


            return result;
        }
    }

}
