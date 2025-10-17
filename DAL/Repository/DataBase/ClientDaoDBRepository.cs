using DAL.DAO;

namespace DAL.Repository.DataBase;

public class ClientDaoDBRepository : EfRepository<ClientDao>
{
    public ClientDaoDBRepository(ShopEntityContext dbContext) : base(dbContext) { }
}