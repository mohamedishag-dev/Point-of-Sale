using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using System.Data;

namespace POS_Business.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository repo;
        public StockMovementService(IStockMovementRepository movementRepository)
        {
            repo = movementRepository;
        }
        public DataTable GetAllMovements()
        {
            return repo.GetAllMovements();
        }



    }
}
