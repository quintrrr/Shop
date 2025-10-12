using Core.Classes;
using DAL.DAO;

namespace DAL.Repository.File;

public class ClientDaoFileRepository : FileRepositoryBase<ClientDao>
{
    protected override string Path => "clients.txt";

    protected override List<ClientDao> Deserialize(string text)
    {
        var lines = text.Split(Environment.NewLine);
        var clients = new List<ClientDao>();
        foreach (var line in lines)
        {
            var str = line.Split(';');
            var client = new ClientDao
            (
                Guid.Parse(str[0]),
                str[1],
                str[2],
                str[3],
                DateTime.Parse(str[4])
            );
            clients.Add(client);
        }
        return clients;
    }

    protected override string Serialize(List<ClientDao> list) =>
        string.Join(Environment.NewLine, list.Select(c => c.ToString()));
}