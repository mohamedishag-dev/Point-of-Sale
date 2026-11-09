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
        int AddSaleItem(SaleItem Item);
        bool UpdateSaleItem(SaleItem Item);
        SaleItem GetBySaleItemID(int ItemID);
        List<SaleItem> GetAllSaleItems(int SaleID);

    }
}
