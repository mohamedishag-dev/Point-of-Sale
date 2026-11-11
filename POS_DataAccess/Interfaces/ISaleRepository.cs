using POS_DataAccess.Models;
using System.Threading.Tasks;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface ISaleRepository
    {
        bool SaveChanges();
        DataTable GetAllSales();
        bool IsExists(int saleID);
        int AddNewSale(Sale sale);
        bool UpdateSale(Sale sale);
        Sale GetBySaleID(int saleID);

    }
}
