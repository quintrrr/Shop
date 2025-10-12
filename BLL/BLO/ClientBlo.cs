using Core.Interfaces;

namespace BLL.BLO;

public class ClientBlo : IPrimary
{
    public Guid Id { get; private set; }

    private string _firstName = string.Empty;
    private string _lastName = string.Empty;

    private DateTime _birthday;
    
    public string Patronymic { get; set; } = string.Empty;
    
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Имя клиента должно содержать хотя бы 1 символ");
            
            _firstName = value;
        }
    }
    
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Фамилия клиента должна содержать хотя бы 1 символ");
            
            _lastName = value;
        }
    }
    
    public DateTime Birthday { 
        get => _birthday;
        set
        {
            if (value == default) 
                throw new ArgumentException("Дата рождения не должна быть пустой");
            if (DateTime.Today < value)
                throw new ArgumentException("Невалидная дата рождения");
            
            _birthday = value;
        }
    }
    
    public int Age {
        get
        {
            if (DateTime.Now.Month > Birthday.Month ||
                DateTime.Now.Month == Birthday.Month && DateTime.Now.Day >= Birthday.Day)
            {
                return DateTime.Now.Year - Birthday.Year;
            }
            return DateTime.Now.Year - Birthday.Year - 1;
        }
        
    }

    public ClientBlo(
        string firstName,
        string lastName,
        string patronymic = "", 
        DateTime? birthday = null)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday ?? new DateTime(1900, 1, 1);
    }
    
    public ClientBlo(
        Guid id,
        string firstName,
        string lastName,
        string patronymic = "", 
        DateTime? birthday = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday ?? new DateTime(1900, 1, 1);
    }
}