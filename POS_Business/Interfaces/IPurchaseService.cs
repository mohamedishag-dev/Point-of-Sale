using POS_Business.DTOs.Purchases;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Interfaces
{
    public interface IPurchaseService
    {
        DataTable GetAllPurchases();
        bool AddPurchase(PurchaseDto purchase);
        bool IsPurchaseExists(int purchaseID);
        bool UpdatePurchase(PurchaseDto purchase);
        PurchaseDto GetPurchaseByID(int purchaseId);

    }
}
