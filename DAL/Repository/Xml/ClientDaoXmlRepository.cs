using DAL.DAO;

namespace DAL.Repository.Xml;

public class ClientDaoXmlRepository : XmlRepository<ClientDao>
{
    public ClientDaoXmlRepository(string path) : base(path)
    {
    }
}