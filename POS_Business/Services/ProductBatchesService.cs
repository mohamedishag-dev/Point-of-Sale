using POS_Business.interfaceis;
using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class ProductBatchesService : IProductBatchesService
    {

        private readonly IProductBatchesRepository _repo;
        public ProductBatchesService(IProductBatchesRepository repository)
        {
            _repo = repository;

        }

        public DataTable GetAll()
        {
            return _repo.GetAll();

        }

        public bool DeleteBath(int batchID)
        {
            if (_repo.IsBathExists(batchID))
                return _repo.DeleteBath(batchID);

            return false;
        }

        public bool IsBathExists(int batchID)
        {

            return _repo.IsBathExists(batchID);

        }

        public bool UpdateBath(ProductBatches batch)
        {
            if (batch == null)
                return false;

            return _repo.UpdateBath(batch);

        }

        public ProductBatches GetBathById(int batchID)
        {
            return _repo.GetBathById(batchID);

        }

        public bool AddNewBath(ProductBatches batch, int createdBy)
        {
            if (batch == null && createdBy <= 0)
                return false;

            batch.CreatedBy = createdBy;

            batch.BatchID = _repo.AddNewBath(batch);
            return (batch.BatchID != -1);

        }

    }
}
