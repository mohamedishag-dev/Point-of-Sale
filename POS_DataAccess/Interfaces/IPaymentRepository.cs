using POS_DataAccess.Models;
using System.Collections.Generic;

namespace POS_DataAccess.Interfaces
{
    public interface IPaymentRepository
    {
        int AddPayment(Payment payment);
        List<Payment> GetAllPayments(int SaleID);

    }
}
