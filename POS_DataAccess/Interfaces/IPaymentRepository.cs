using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.Interfaces
{
    public interface IPaymentRepository
    {
        int AddPayment(Payment payment);
        List<Payment> GetAllPayments(int SaleID);
    
    
    }
}
