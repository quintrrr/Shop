using DAL.DAO;

namespace DAL.Repository.Xml;

public class GoodDaoXmlRepository : XmlRepository<GoodDao>
{
    public GoodDaoXmlRepository(string path) : base(path)
    {
    }
}