using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.interfaceis
{
    public interface ISaleRepository
    {
        DataTable GetAllSales();
        int AddNewSale(Sale sale);
        int AddSaleItem(SaleItem Item);

        bool IsExists(int saleID);

        bool UpdateSale(Sale sale);
        bool UpdateSaleItem(SaleItem sale);

        Sale GetBySaleID(int saleID);
        List<SaleItem> GetAllSaleItems(int saleID);


    }
}
