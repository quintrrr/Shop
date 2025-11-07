using BLL.BLO;
using DAL.DAO;
using Core.Interfaces;

namespace Mapping;

public class GoodMapper : IMapper<GoodBlo, GoodDao>
{
    public GoodDao ToDao(GoodBlo goodBlo)
    {
        return new GoodDao
        {
            Id = goodBlo.Id,
            Code = goodBlo.Code,
            Name = goodBlo.Name,
        };
    }

    public GoodBlo ToBlo(GoodDao goodDao)
    {
        return new GoodBlo(
            goodDao.Id,
            goodDao.Name,
            goodDao.Code);
    }
}