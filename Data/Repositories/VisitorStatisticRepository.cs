using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public interface IVisitorStatisticRepository : IRepository<VisitStatistic>
    {
    }

    public class VisitorStatisticRepository : RepositoryBase<VisitStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) 

                : base(dbFactory)

            {
        }
    }
}