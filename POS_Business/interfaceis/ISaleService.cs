using System;
using System.Data;
using POS_Business.DTOs;
using System.Collections.Generic;

namespace POS_Business.interfaceis
{
    public interface ISaleService
    {
        DataTable GetAllSales();
        bool IsExists(int saleID);
        bool AddSale(SaleDto saleDto);
        SaleDto GetBySaleID(int saleID);
        bool UpdateSale(SaleDto saleDto);

    }
}
