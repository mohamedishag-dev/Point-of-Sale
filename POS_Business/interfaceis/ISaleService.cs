using POS_Business.DTOs;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.interfaceis
{
    public interface ISaleService
    {
        DataTable GetAllSales();
        bool IsExists(int saleID);
        bool UpdateSale(SaleDto sale);
        bool AddNewSale(SaleDto sale);
        SaleDto GetBySaleID(int saleID);

    }
}
