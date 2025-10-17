using DAL.DAO;

namespace DAL.Repository.DataBase;

public class GoodDaoDBRepository : EfRepository<GoodDao>
{
    public GoodDaoDBRepository(ShopEntityContext dbContext) : base(dbContext) { }
}