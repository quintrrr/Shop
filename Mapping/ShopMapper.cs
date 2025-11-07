using BLL.BLO;
using DAL.DAO;
using Core.Interfaces;

namespace Mapping;

public class ShopMapper : IMapper<ShopBlo, ShopDao>
{
    public ShopDao ToDao(ShopBlo shopBlo)
    {
        return new ShopDao
        {
            Id = shopBlo.Id,
            Code = shopBlo.Code,
            Name = shopBlo.Name,
        };
    }

    public ShopBlo ToBlo(ShopDao shopDao)
    {
        return new ShopBlo(
            shopDao.Id,
            shopDao.Name,
            shopDao.Code);
    }
}