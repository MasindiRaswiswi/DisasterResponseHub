using DisasterResponseHub.ResourceAccess;

namespace DisasterResponseHub.Data
{
    public class CRepositoryWrapper : IRepositoryWrapper
    {
        AppDbContext _dbContext { get; set; }
        CRepositoryDonor _repositoryDonor { get ; set; }
        public CRepositoryWrapper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRespositoryDonor _RepositoryDonor
        {
            get
            {
                if (_repositoryDonor == null)
                    _repositoryDonor = new CRepositoryDonor(_dbContext);
                return _repositoryDonor;
            }
        }

    }
}
