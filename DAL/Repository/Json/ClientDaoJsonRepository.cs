using DAL.DAO;

namespace DAL.Repository.Json;

public class ClientDaoJsonRepository: JsonRepository<ClientDao>
{
    public ClientDaoJsonRepository(string path) : base(path)
    {
    }
}