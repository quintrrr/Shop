using BLL.BLO;
using DAL.DAO;
using Core.Interfaces;

namespace Mapping;

public class ClientMapper : IMapper<ClientBlo, AccountDao>
{
    public AccountDao ToDao(ClientBlo clientBlo)
    {
        return new AccountDao
        {
            Id = clientBlo.Id,
            FirstName = clientBlo.FirstName,
            LastName = clientBlo.LastName,
            Patronymic = clientBlo.Patronymic,
            DateBorn = new DateTimeOffset(clientBlo.Birthday ?? new DateTime(1900, 1, 1),
                TimeSpan.Zero).ToUnixTimeSeconds(),
        };
    }

    public ClientBlo ToBlo(AccountDao accountDao)
    {
        return new ClientBlo(
            accountDao.Id,
            accountDao.FirstName,
            accountDao.LastName, 
            accountDao.Patronymic, 
            DateTimeOffset.FromUnixTimeSeconds(accountDao.DateBorn).UtcDateTime);
    }
}