using DAL.DAO;

namespace DAL.Repository.Xml;

public class ShopDaoXmlRepository : XmlRepository<ShopDao>
{
    public ShopDaoXmlRepository(string path) : base(path)
    {
    }
}