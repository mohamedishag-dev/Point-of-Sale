using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IPurchaseRepository
    {
        DataTable GetAllPurchases();
        int AddPurchase(Purchase purchase);
        bool IsPurchaseExists(int purchaseID);
        bool UpdatePurchase(Purchase purchase);
        Purchase GetPurchaseByID(int purchaseId);
    }
}
