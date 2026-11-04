using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.interfaceis
{
    public interface IProductBatchesRepository
    {
        DataTable GetAll();
        bool DeleteBath(int productID);
        int AddNewBath(ProductBatches batch);
        bool UpdateBath(ProductBatches batch);
        bool IsBathExists(int batchID);
        ProductBatches GetBathById(int batchID);

    }
}
