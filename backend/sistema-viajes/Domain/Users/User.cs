using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Users;

public sealed class User : AggregateRoot {

    public User(UserId id , string name , string email ,string password , Rol rol,bool active){
        Id = id;
        Name = name;
        Email = email;
        Password= password;
        Rol = rol;
        Active=active;
    }

     private User() { }

    public UserId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; }
    public Rol Rol { get; private set; }
    public bool Active{get;private set;}
}