using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.Interfaces
{
    public interface IStockMovementService
    {
        DataTable GetAllMovements();
      //  bool IsExists(int movementID);
      //  bool GetByMovementID(int movementID);
      //  bool AddMovement(StockMovement movement);
      //  bool UpdateMovement(StockMovement movement);

    }
}
