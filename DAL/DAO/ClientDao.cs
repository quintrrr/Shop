using Core.Interfaces;

namespace DAL.DAO;

public class ClientDao : IPrimary
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    
    public DateTime DateOfBirth { get; set; }
    public int Age {
        get
        {
            if (DateTime.Now.Month > DateOfBirth.Month ||
                DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day >= DateOfBirth.Day)
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
            return DateTime.Now.Year - DateOfBirth.Year - 1;
        }
    }
    
    public ClientDao(Guid id, string firstName, string lastName, string patronymic, DateTime dateOfBirth)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        DateOfBirth = dateOfBirth;
    }

    public ClientDao()
    {
        
    }
    
    public override string ToString()
    {
        return $"{Id};{FirstName};{LastName};{Patronymic};{DateOfBirth:o}";
    }
}