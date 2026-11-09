using System.Data;
using POS_Business.DTOs;
using POS_DataAccess.Models;
using POS_Business.interfaceis;
using POS_DataAccess.interfaceis;

namespace POS_Business.Services
{
    public class SaleService : ISaleService
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

        public bool AddSale(SaleDto saleDto)
        {
            if (saleDto == null)
                return false;

            if (saleDto.Items == null)
                return false;

            Sale sale = new Sale
            {
                CustomerID = saleDto.CustomerID,
                UserID = saleDto.UserID,
                SubTotal = saleDto.SubTotal,
                Discount = saleDto.Discount,
                Tax = saleDto.Tax,
                PaidAmount = saleDto.PaidAmount,
                SaleStatus = saleDto.SaleStatus,
                SaleDate = saleDto.SaleDate,
                LastStatusDate = saleDto.LastStatusDate,
                Notes = saleDto.Notes,

            };

            foreach (var item in saleDto.Items)
            {
                sale.Items.Add(new SaleItem
                {
                    BatchID = item.BatchID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });

            }

            sale.SaleID = _repo.AddNewSale(sale);

            return (sale.SaleID != -1);
        }

        public SaleDto GetBySaleID(int saleID)
        {
            return null;
        }

        public bool UpdateSale(SaleDto saleDto)
        {
            if (saleDto == null)
                return false;


            Sale sale = new Sale
            {
                SaleID = saleDto.SaleID,
                CustomerID = saleDto.CustomerID,
                UserID = saleDto.UserID,
                SubTotal = saleDto.SubTotal,
                Discount = saleDto.Discount,
                PaidAmount = saleDto.PaidAmount,
                //  TotalAmount = saleDto.TotalAmount,

            };

            return _repo.UpdateSale(sale);
        }

    }
}
