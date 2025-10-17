using Core.Interfaces;

namespace DAL.DAO;

public class AccountDao : IPrimary
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    
    public long DateBorn { get; set; }
    
    
    public AccountDao(Guid id, string firstName, string lastName, string patronymic, long dateBorn)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        DateBorn = dateBorn;
    }

    public AccountDao()
    {
        
    }
    
    public override string ToString()
    {
        return $"{Id};{FirstName};{LastName};{Patronymic};{DateBorn}";
    }
}