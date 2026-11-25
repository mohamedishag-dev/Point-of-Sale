using POS_Business.Security;
using POS_Business.Security.Sales;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Interfaces
{
    public interface ISaleService
    {
        DataTable GetAllSales();
        bool IsExists(int saleID);
        SaleDto GetBySaleID(int saleID);
        bool UpdateSale(SaleDto saleDto);
        bool AddSale(SaleDto saleDto, PaymentDto paymentDto);

    }
}
