using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.interfaceis
{
    public interface IProductBatchesService
    {
        DataTable GetAll();
        bool DeleteBath(int productID);
        bool IsBathExists(int batchID);
        bool UpdateBath(ProductBatches batch);
        ProductBatches GetBathById(int batchID);
        bool AddNewBath(ProductBatches batch, int CreatedBy);

    }
}

