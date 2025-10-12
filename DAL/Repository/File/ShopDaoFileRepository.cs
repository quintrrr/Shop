using Core.Classes;
using DAL.DAO;

namespace DAL.Repository.File;

public class ShopDaoFileRepository : FileRepositoryBase<ShopDao>
{
    protected override string Path => "shops.txt";

    protected override List<ShopDao> Deserialize(string text)
    {
        var lines = text.Split(Environment.NewLine);
        var shops = new List<ShopDao>();
        foreach (var line in lines)
        {
            var str = line.Split(';');
            var shop = new ShopDao
            (
                Guid.Parse(str[0]),
                str[1],
                int.Parse(str[2])
            );
            shops.Add(shop);
        }
        return shops;
    }

    protected override string Serialize(List<ShopDao> list) =>
        string.Join(Environment.NewLine, list.Select(c => c.ToString()));
}