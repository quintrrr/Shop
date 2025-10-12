using DAL.DAO;

namespace DAL.Repository.DataBase;

public class ShopDaoDataBaseRepository : EfRepository<ShopDao>
{
   public ShopDaoDataBaseRepository(ShopEntityContext dbContext) : base(dbContext) { }
}