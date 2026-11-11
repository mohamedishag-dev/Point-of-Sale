using System.Collections.Generic;
using POS_DataAccess.Models;

namespace POS_DataAccess.Interfaces
{
    public interface ISaleItemsRepository
    {
        int AddItem(SaleItem Item);
        bool UpdateItem(SaleItem Item);
        SaleItem GetByItemID(int ItemID);
        List<SaleItem> GetAllItems(int SaleID);

    }
}
