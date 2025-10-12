using DAL.DAO;

namespace DAL.Repository.Json;

public class ShopDaoJsonRepository : JsonRepository<ShopDao>
{
    public ShopDaoJsonRepository(string path) : base(path) { }
}