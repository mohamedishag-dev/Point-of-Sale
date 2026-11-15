using POS_Business.DTOs;
using POS_Business.DTOs.Sales;
using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Linq;

namespace POS_Business.Services
{
    public class SaleService : ISaleService
    {

        private readonly ISaleRepository _sales;
        private readonly IProductRepository _products;
        private readonly IPaymentRepository _payments;
        private readonly IStockMovementRepository _stockMovements;

        public SaleService(
            ISaleRepository sales,
            IProductRepository products,
            IStockMovementRepository StockMovement,
            IPaymentRepository payments)
        {
            _sales = sales;
            _products = products;
            _payments = payments;
            _stockMovements = StockMovement;
        }

        public DataTable GetAllSales()
        {
            return _sales.GetAllSales();

        }

        public bool IsExists(int saleID)
        {
            return _sales.IsExists(saleID);
        }

        public SaleDto GetBySaleID(int saleID)
        {
            if (saleID <= 0)
                return null;

            Sale sale = _sales.GetBySaleID(saleID);

            if (sale == null)
                return null;

            return MapToDto(sale);

        }


        internal static SaleDto MapToDto(Sale sale)
        {
            var dto = new SaleDto
            {
                SaleID = sale.SaleID,
                CustomerID = sale.CustomerID,
                UserID = sale.UserID,
                Discount = sale.Discount,
                Tax = sale.Tax,
                PaidAmount = sale.PaidAmount,
                SaleStatus = sale.SaleStatus,
                SaleDate = sale.SaleDate,             
                LastStatusDate = sale.LastStatusDate,
                Notes = sale.Notes
            };


            if (sale.Items != null)
            {
                foreach (var item in sale.Items)
                {
                    dto.Items.Add(new SaleItemDto
                    {
                        SaleID = item.SaleID,
                        BatchID = item.BatchID,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    });
                }
            }
            return dto;
        }
        internal static Sale MapToModel(SaleDto dto)
        {
            var sale = new Sale
            {
                CustomerID = dto.CustomerID,
                UserID = dto.UserID,
                SubTotal = dto.SubTotal,
                Discount = dto.Discount,
                Tax = dto.Tax,
                PaidAmount = dto.PaidAmount,
                SaleStatus = dto.SaleStatus,
                SaleDate = dto.SaleDate,
                LastStatusDate = dto.LastStatusDate,
                Notes = dto.Notes
            };

            foreach (var item in dto.Items)
            {
                sale.Items.Add(new SaleItem
                {
                    BatchID = item.BatchID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            return sale;
        }


        public bool AddPayment(Payment payment)
        {
            if (payment == null)
                return false;

            payment.PaymentID = _payments.AddPayment(payment);
            if (payment.PaymentID != -1)
            {
                _sales.SaveChanges();
            }
            return (payment.PaymentID != -1);

        }

        public bool UpdateSale(SaleDto saleDto)
        {
            if (saleDto == null)
                return false;

            Sale sale = MapToModel(saleDto);

            return _sales.UpdateSale(sale);
        }
   
        public bool AddSale(SaleDto saleDto, PaymentDto paymentDto)
        {

            if (saleDto == null)
                return false;
           
            if (paymentDto == null)
                return false;

            if (saleDto.Items == null)
                return false;

            if (saleDto.Items.Any(i => i.Quantity <= 0 || i.UnitPrice < 0))
                return false;

            Sale sale = MapToModel(saleDto);

       
            sale.SaleDate = DateTime.Now;
            sale.LastStatusDate = sale.SaleDate;

            sale.SaleID = _sales.AddSale(sale);

            foreach (var item in sale.Items)
            {
                _stockMovements.AddMovement(new StockMovement
                {
                    BatchID = item.BatchID,
                    UserID = sale.UserID,
                    SaleID = sale.SaleID,
                    Quantity = item.Quantity,
                    MovementType = 1,
                    TotalAmount = item.Quantity * item.UnitPrice,
                    CreatedAt = DateTime.Now,
                });
            }


            _payments.AddPayment(new Payment
            {
                SaleID = sale.SaleID,
                Amount = paymentDto.Amount,
                PaymentMethod = paymentDto.PaymentMethod,
                UserID = paymentDto.UserID,
                Notes = paymentDto.Notes,
                PaymentDate = DateTime.Now
            });


            return (sale.SaleID != -1);
        }



    }
}
