

using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Collaborators;
public sealed class Collaborator : AggregateRoot{
    

    public Collaborator(CollaboratorId id , string name,string lastName,string email ,PhoneNumber phoneNumber,bool active ){
        CollaboratorId=id;
        Name=name;
        LastName=lastName;
        Email=email;
        PhoneNumber=phoneNumber;
        Active=active;
     }

    public Collaborator(){

    }


    public CollaboratorId CollaboratorId {get;private set;}

    public string Name{get;private set;}= string.Empty;

    public string LastName{get;private set;}=string.Empty;

    public string FullName => $"{Name} {LastName}";

    public string Email {get;private set;}=string.Empty;

    public PhoneNumber PhoneNumber {get;private set;}

    public bool Active{get;private set;}
}