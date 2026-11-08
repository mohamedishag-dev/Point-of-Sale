using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.interfaceis
{
    public interface ISaleItemsRepository
    {
        bool IsExists(int saleID);
        int AddSaleItem(Sale sale);
        DataTable GetAllSaleItems();
        bool UpdateSaleItem(Sale sale);
        Sale GetBySaleItemID(int saleID);
    }
}
