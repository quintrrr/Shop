using DAL.DAO;

namespace DAL.Repository.DataBase;

public class ShopDaoDBRepository : EfRepository<ShopDao>
{
   public ShopDaoDBRepository(ShopEntityContext dbContext) : base(dbContext) { }
}