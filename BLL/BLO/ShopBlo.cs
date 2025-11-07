using System.Text.Json.Serialization;
using Core.Interfaces;

namespace BLL.BLO;

public class ShopBlo : IPrimary
{
    public Guid Id { get; private set; }
    
    private string _name = string.Empty;
    private int _code;
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Название магазина должно содержать хотя бы 1 символ");
            
            _name = value;
        }
    }

    public int Code
    {
        get => _code;
        set
        {
            if (int.IsNegative(value)) 
                throw new ArgumentException("Код магазина должен быть положительным");
            
            _code = value;
        }
    }

    public ShopBlo(Guid id, string name, int code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    [JsonConstructor]
    public ShopBlo(string name, int code)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
    }
}