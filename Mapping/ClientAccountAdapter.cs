using BLL.BLO;
using DAL.DAO;

namespace Mapping;

public static class ClientAccountAdapter
{
    public static AccountDao ToDao(ClientBlo clientBlo)
    {
        return new AccountDao
        {
            Id = clientBlo.Id,
            FirstName = clientBlo.FirstName,
            LastName = clientBlo.LastName,
            Patronymic = clientBlo.Patronymic,
            DateBorn = new DateTimeOffset(clientBlo.Birthday, TimeSpan.Zero).ToUnixTimeSeconds(),
        };
    }

    public static ClientBlo ToBlo(AccountDao accountDao)
    {
        return new ClientBlo(
            accountDao.Id,
            accountDao.FirstName,
            accountDao.LastName, 
            accountDao.Patronymic, 
            DateTimeOffset.FromUnixTimeSeconds(accountDao.DateBorn).UtcDateTime);
    }
}