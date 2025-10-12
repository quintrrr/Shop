using Core.Classes;
using DAL.DAO;

namespace DAL.Repository.File;

public class GoodDaoFileRepository : FileRepositoryBase<GoodDao>
{
    protected override string Path => "goods.txt";

    protected override List<GoodDao> Deserialize(string text)
    {
        var lines = text.Split(Environment.NewLine);
        var goods = new List<GoodDao>();
        foreach (var line in lines)
        {
            var str = line.Split(';');
            var good = new GoodDao
            (
                Guid.Parse(str[0]),
                str[1],
                int.Parse(str[2])
            );
            goods.Add(good);
        }
        return goods;
    }

    protected override string Serialize(List<GoodDao> list) =>
        string.Join(Environment.NewLine, list.Select(c => c.ToString()));
    
}