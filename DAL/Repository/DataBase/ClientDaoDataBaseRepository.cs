using DAL.DAO;

namespace DAL.Repository.DataBase;

public class ClientDaoDataBaseRepository : EfRepository<ClientDao>
{
    public ClientDaoDataBaseRepository(ShopEntityContext dbContext) : base(dbContext) { }
}