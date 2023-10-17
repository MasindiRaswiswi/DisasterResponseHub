using DisasterResponseHub.ResourceAccess;

namespace DisasterResponseHub.Data
{
    public class CRepositoryWrapper : IRepositoryWrapper
    {
        AppDbContext _dbContext { get; set; }

        public CRepositoryWrapper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
