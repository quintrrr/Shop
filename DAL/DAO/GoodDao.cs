using Core.Interfaces;

namespace DAL.DAO;

public class GoodDao : IPrimary
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Code { get; set; }

    public GoodDao(Guid id, string name, int code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public GoodDao()
    {
        
    }
    
    public override string ToString()
    {
        return $"{Id};{Name};{Code}";
    }
}