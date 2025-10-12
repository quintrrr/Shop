using DAL.DAO;

namespace DAL.Repository.DataBase;

public class GoodDaoDataBaseRepository : EfRepository<GoodDao>
{
    public GoodDaoDataBaseRepository(ShopEntityContext dbContext) : base(dbContext) { }
}