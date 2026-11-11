using POS_Business.DTOs.Purchases;
using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repo;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _repo = purchaseRepository;

        }

        public DataTable GetAllPurchases()
        {
            return _repo.GetAllPurchases();
        }

        public bool IsPurchaseExists(int purchaseID)
        {
            return _repo.IsPurchaseExists(purchaseID);
        }

        public bool AddPurchase(PurchaseDto purchaseDto)
        {
            if (purchaseDto == null)
                return false;

            Purchase purchase = new Purchase
            {
                SupplierID = purchaseDto.SupplierID,
                UserID = purchaseDto.UserID,
                PurchaseDate = purchaseDto.PurchaseDate,
                PaidAmount = purchaseDto.PaidAmount,
                TotalAmount = purchaseDto.TotalAmount
            };

            purchase.PurchaseID = _repo.AddPurchase(purchase);
            return (purchase.PurchaseID > 0);
        }

        public PurchaseDto GetPurchaseByID(int purchaseID)
        {
            Purchase purchase = _repo.GetPurchaseByID(purchaseID);
            if (purchase == null)
                return null;

            return new PurchaseDto
            {
                PurchaseID = purchase.PurchaseID,
                SupplierID = purchase.SupplierID,
                UserID = purchase.UserID,
                PurchaseDate = purchase.PurchaseDate,
                TotalAmount = purchase.TotalAmount,
                PaidAmount = purchase.PaidAmount
            };

        }

        public bool UpdatePurchase(PurchaseDto purchaseDto)
        {
            if (purchaseDto == null)
                return false;

            Purchase purchase = new Purchase
            {
                PurchaseID = purchaseDto.PurchaseID,
                SupplierID = purchaseDto.SupplierID,
                UserID = purchaseDto.UserID,
                TotalAmount = purchaseDto.TotalAmount,
                PaidAmount = purchaseDto.PaidAmount
            };

            return _repo.UpdatePurchase(purchase);
        }


    }
}
