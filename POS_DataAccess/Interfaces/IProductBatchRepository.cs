using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IProductBatchRepository
    {
        DataTable GetAll();
        bool IsBathExists(int batchID);
        bool DeleteBath(int productID);
        int AddNewBath(ProductBatches batch);
        bool UpdateBath(ProductBatches batch);
        ProductBatches GetBathById(int batchID);

    }
}
