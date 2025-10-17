using Core.Interfaces;
using DAL;
using DAL.DAO;
using DAL.Repository;
using DAL.Repository.DataBase;
using DAL.Repository.File;
using DAL.Repository.Json;
using DAL.Repository.Xml;


namespace UIL;

class Program
{
    static void Main(string[] args)
    {
        const string dataSource = "shop.db";
        var dbContext = new ShopEntityContext(dataSource);
        
        TestShops(new ShopDaoDBRepository(dbContext));
        TestShops(new ShopDaoFileRepository());
        TestShops(new ShopDaoJsonRepository("shops.json"));
        TestShops(new ShopDaoXmlRepository("shops.xml"));
        
        TestClients(new ClientDaoDBRepository(dbContext));
        TestClients(new ClientDaoFileRepository());
        TestClients(new ClientDaoJsonRepository("clients.json"));
        TestClients(new ClientDaoXmlRepository("clients.xml"));
        
        TestGoods(new GoodDaoDBRepository(dbContext));
        TestGoods(new GoodDaoFileRepository());
        TestGoods(new GoodDaoJsonRepository("goods.json"));
        TestGoods(new GoodDaoXmlRepository("goods.xml"));
    }

    private static void TestShops(IRepository<ShopDao> repo)
    {
        var shops = new List<ShopDao>
        {
            new (Guid.NewGuid(), "Гастроном «ВкусМаркет»", 101),
            new (Guid.NewGuid(), "Супермаркет «СемьДней»", 202),
            new (Guid.NewGuid(), "Минимаркет «У дома»", 303)
        };
        
        foreach (var shop in shops)
        {
            repo.Create(shop);
            repo.Create(shop);
        }

        PrintAll(repo);
        
        var newShop = repo.Read(shops[0].Id);
        if (newShop is not null)
        {
            newShop.Name = "ВкусВилл";
            repo.Update(newShop);
        }

        PrintAll(repo);
        
        repo.Delete(shops[1].Id);

        PrintAll(repo);
    }
    
    static void TestGoods(IRepository<GoodDao> repo)
    {
        var goods = new List<GoodDao>
        {
            new (Guid.NewGuid(), "Кока-Кола 1.5 л", 1001),
            new (Guid.NewGuid(), "Пепси 1.5 л", 1002),
            new (Guid.NewGuid(), "Кетчуп Heinz томатный 460 г", 1003),
            new (Guid.NewGuid(), "Спагетти Barilla №5 500 г", 1004),
            new (Guid.NewGuid(), "Шоколадно-ореховая паста Nutella 350 г", 1005),
            new (Guid.NewGuid(), "Кофе молотый Lavazza Qualità Rossa 250 г", 1006),
            new (Guid.NewGuid(), "Чай черный Earl Grey Twinings 100 пак.", 1007),
            new (Guid.NewGuid(), "Шоколад Ritter Sport Молочный Альпийский 100 г", 1008),
            new (Guid.NewGuid(), "Шоколад Milka Альпийский молочный 100 г", 1009),
            new (Guid.NewGuid(), "Драже M&M’s с арахисом 200 г", 1010),
            new (Guid.NewGuid(), "Чипсы Pringles оригинальные 165 г", 1011),
            new (Guid.NewGuid(), "Чипсы Lay’s соль 150 г", 1012),
            new (Guid.NewGuid(), "Печенье Oreo классическое 228 г", 1013),
            new (Guid.NewGuid(), "Йогурт греческий Danone 140 г", 1014),
            new (Guid.NewGuid(), "Масло сливочное Président 82% 200 г", 1015),
            new (Guid.NewGuid(), "Сыр сливочный Philadelphia 200 г", 1016),
            new (Guid.NewGuid(), "Капсулы для стирки Tide Pods 15 шт.", 1017),
            new (Guid.NewGuid(), "Гель для стирки Persil Universal 1.46 л", 1018),
            new (Guid.NewGuid(), "Средство для мытья посуды Fairy Лимон 900 мл", 1019),
            new (Guid.NewGuid(), "Таблетки для посудомоечной машины Finish 30 шт.", 1020),
            new (Guid.NewGuid(), "Зубная паста Colgate Total 75 мл", 1021),
            new (Guid.NewGuid(), "Зубная щетка Oral-B Pro Expert", 1022),
            new (Guid.NewGuid(), "Шампунь Head & Shoulders Classic Clean 400 мл", 1023),
            new (Guid.NewGuid(), "Шампунь Pantene Pro-V Repair & Protect 400 мл", 1024),
            new (Guid.NewGuid(), "Крем увлажняющий NIVEA Soft 100 мл", 1025),
            new (Guid.NewGuid(), "Мыло Dove Beauty Bar 100 г", 1026),
            new (Guid.NewGuid(), "Дезодорант L’Oréal Men Expert 150 мл", 1027),
            new (Guid.NewGuid(), "Подгузники Pampers Active Baby размер 3", 1028),
            new (Guid.NewGuid(), "Подгузники Huggies Elite Soft размер 4", 1029),
            new (Guid.NewGuid(), "Гигиенические прокладки Always Ultra Normal 10 шт.", 1030)
        };
        
        foreach (var good in goods)
        {
            repo.Create(good);
            repo.Create(good);
        }
        
        var newGood = repo.Read(goods[0].Id);
        if (newGood is not null)
        {
            newGood.Name = "Добрый кола 1.5 л";
            repo.Update(newGood);
        }
        
        repo.Delete(goods[1].Id);

        PrintAll(repo);
    }
    
    static void TestClients(IRepository<ClientDao> repo)
    {
        var clients = new List<ClientDao>
        {
            new (Guid.NewGuid(), "Алексей", "Иванов", "Сергеевич", new DateTime(1992, 3, 14)),
            new (Guid.NewGuid(), "Мария", "Петрова", "Андреевна", new DateTime(1988, 11, 2)),
            new (Guid.NewGuid(), "Илья", "Сидоров", "Дмитриевич", new DateTime(1996, 7, 25)),
            new (Guid.NewGuid(), "Екатерина", "Соколова", "Павловна", new DateTime(2000, 1, 9)),
            new (Guid.NewGuid(), "Наталья", "Кузнецова", "Игоревна", new DateTime(1994, 5, 30))
        };
        
        foreach (var client in clients)
        {
            repo.Create(client);
            repo.Create(client);
        }
        
        var newClient = repo.Read(clients[0].Id);
        if (newClient is not null)
        {
            newClient.FirstName = "Иван";
            repo.Update(newClient);
        }
        
        repo.Delete(clients[1].Id);
        
        PrintAll(repo);
    }

    private static void PrintAll<T>(IRepository<T> repo)
    {
        Console.WriteLine();
        
        var entities = repo.ReadAll();

        foreach (var entity in entities)
        {
            Console.WriteLine(entity);
        }
    }
}