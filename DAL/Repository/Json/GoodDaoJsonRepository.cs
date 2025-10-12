using DAL.DAO;

namespace DAL.Repository.Json;

public class GoodDaoJsonRepository : JsonRepository<GoodDao>
{
    public GoodDaoJsonRepository(string path) : base(path)
    {
    }
}