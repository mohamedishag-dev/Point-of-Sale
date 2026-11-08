using POS_Business.DTOs;
using POS_Business.interfaceis;
using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.Services
{
    public class SaleService: ISaleService
    {
        private readonly ISaleRepository _repo;
        public SaleService(ISaleRepository repository)
        {
            _repo = repository;
        }

        public DataTable GetAllSales()
        {
            return _repo.GetAllSales();

        }

        public bool IsExists(int saleID)
        {
            return _repo.IsExists(saleID);

        }

        public bool UpdateSale(SaleDto saleDto)
        {
            Sale sale = new Sale
            {
                SaleID = saleDto.SaleID,
                CustomerID=saleDto.CustomerID,
                UserID=saleDto.UserID,
                SubTotal = saleDto.SubTotal,
                Discount = saleDto.Discount,
                PaidAmount = saleDto.PaidAmount,
                TotalAmount = saleDto.TotalAmount,

            };

            return _repo.UpdateSale(sale);
        }
        public bool AddNewSale(SaleDto sale)
        {
            return false;
        }
        public SaleDto GetBySaleID(int saleID)
        {
            return new SaleDto();
        }

    }
}
