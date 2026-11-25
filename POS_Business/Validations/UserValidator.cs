using POS_Business.Security.Users;

namespace POS_Business.Validations
{
    public static class UserValidator
    {
        public static ValidationResult Validate(CreateUserDto user)
        {
            var result = new ValidationResult();

            if (user == null) { result.Add("بيانات المستخدم غير موجودة"); return result; }

            if (string.IsNullOrWhiteSpace(user.FullName))
                result.Add("الاسم مطلوب");

            if (string.IsNullOrWhiteSpace(user.Username))
                result.Add("اسم المستخدم مطلوب"); 

            if (string.IsNullOrWhiteSpace(user.Password))
                result.Add("كلمة المرور مطلوبة");

            if (string.IsNullOrWhiteSpace(user.Phone))
                result.Add("رقم الهاتف مطلوب");
        
            if (!string.IsNullOrWhiteSpace(user.Email) && !user.Email.Contains("@"))
                result.Add("البريد الإلكتروني غير صحيح");

            return result;
        }
    }
}
