using DAL.DAO;

namespace DAL.Repository.DataBase;

public class AccountDaoDBRepository : EfRepository<AccountDao>
{
    public AccountDaoDBRepository(ShopEntityContext dbContext) : base(dbContext) { }
}