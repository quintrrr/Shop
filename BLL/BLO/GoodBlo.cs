namespace BLL.BLO;

public class GoodBlo
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
                throw new ArgumentException("Название товара должно содержать хотя бы 1 символ");
            
            _name = value;
        }
    }

    public int Code
    {
        get => _code;
        set
        {
            if (int.IsNegative(value)) 
                throw new ArgumentException("Код товара должен быть положительным");
            
            _code = value;
        }
    }

    public GoodBlo(Guid id, string name, int code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public GoodBlo(string name, int code)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
    }
}