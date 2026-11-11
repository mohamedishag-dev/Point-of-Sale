using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
