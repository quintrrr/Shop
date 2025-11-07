using BLL.BLO;
using Core.Interfaces;
using DAL;
using DAL.DAO;
using DAL.Repository.DataBase;
using Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbPath = builder.Configuration.GetSection("Storage").GetValue<string>("DbPath") ?? "shop.db";
builder.Services.AddSingleton(new ShopEntityContext(dbPath));
// уточнить какую из моделей аккаунта использовать
builder.Services.AddSingleton<IRepository<AccountDao>, AccountDaoDBRepository>();
builder.Services.AddSingleton<IRepository<ClientDao>, ClientDaoDBRepository>();
builder.Services.AddSingleton<IRepository<GoodDao>, GoodDaoDBRepository>();
builder.Services.AddSingleton<IRepository<ShopDao>, ShopDaoDBRepository>();

builder.Services.AddSingleton<IMapper<ClientBlo, AccountDao>, ClientMapper>();
builder.Services.AddSingleton<IMapper<GoodBlo, GoodDao>, GoodMapper>();
builder.Services.AddSingleton<IMapper<ShopBlo, ShopDao>, ShopMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();