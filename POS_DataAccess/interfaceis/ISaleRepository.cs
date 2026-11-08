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
        bool IsExists(int saleID);
        bool UpdateSale(Sale sale);
        Sale GetBySaleID(int saleID);

    }
}
