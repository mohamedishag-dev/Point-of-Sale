using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface ISaleRepository
    {
        bool SaveChanges();
        int AddSale(Sale sale);
        DataTable GetAllSales();
        bool IsExists(int saleID);
        bool UpdateSale(Sale sale);
        Sale GetBySaleID(int saleID);

    }
}
