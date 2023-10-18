using DisasterResponseHub.Models;
using DisasterResponseHub.ResourceAccess;

namespace DisasterResponseHub.Data
{
    public class CRepositoryDonor : CRepositoryBase<Donor>, IRespositoryDonor
    {
        public CRepositoryDonor(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
