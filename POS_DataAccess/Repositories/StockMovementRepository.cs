using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        public DataTable GetAllMovements()
        {
            return null;
        }
        public bool IsExists(int movementID)
        {
            return false;
        }
        public bool GetByMovementID(int movementID)
        {
            return false;
        }
        public int AddMovement(StockMovement movement)
        {
            return 0;
        }
        public bool UpdateMovement(StockMovement movement)
        {
            return false;
        }


    }
}
