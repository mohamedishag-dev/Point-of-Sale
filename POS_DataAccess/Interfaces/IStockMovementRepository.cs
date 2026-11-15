using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IStockMovementRepository
    {
        DataTable GetAllMovements();
        bool IsExists(int movementID);
        bool GetByMovementID(int movementID);
        int AddMovement(StockMovement movement);
        bool UpdateMovement(StockMovement movement);

    }
}
