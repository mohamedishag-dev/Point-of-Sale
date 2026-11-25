using POS_Business.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.Validations
{
    public static class SaleValidator
    {
        public static ValidationResult Validate(SaleDto sale)
        {
            var result = new ValidationResult();

            if (sale == null) { result.Add("بيانات الفاتورة غير موجودة"); return result; }

            if (sale.Items == null || sale.Items.Count == 0)
                result.Add("الفاتورة لا تحتوي على أصناف");

            else if (sale.Items.Any(i => i.Quantity <= 0))
                result.Add("الكمية يجب أن تكون أكبر من صفر");

            if (sale.Discount < 0) result.Add("الخصم لا يمكن أن يكون سالبًا");
            if (sale.PaidAmount < 0) result.Add("المبلغ المدفوع غير صحيح");

            return result;
        }
    }

}
