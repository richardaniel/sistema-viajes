

using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;
public sealed class Customer : AggregateRoot{
    

    public Customer(CustomerId id , string name,string lastName,string email ,PhoneNumber phoneNumber,bool active ){
        CustomerId=id;
        Name=name;
        LastName=lastName;
        Email=email;
        PhoneNumber=phoneNumber;
        Active=active;
     }

    public Customer(){

    }


    public CustomerId CustomerId {get;private set;}

    public string Name{get;private set;}= string.Empty;

    public string LastName{get;private set;}=string.Empty;

    public string FullName => $"{Name} {LastName}";

    public string Email {get;private set;}=string.Empty;

    public PhoneNumber PhoneNumber {get;private set;}

    public bool Active{get;private set;}
}