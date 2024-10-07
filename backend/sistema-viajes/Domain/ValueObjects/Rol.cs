namespace Domain.ValueObjects;

public partial record Rol{
private Rol(string value){
     Value=value;
}

    public static Rol? Create(string value){
        if(string.IsNullOrEmpty(value) ){
            return null;
        }
       return new Rol(value);
    }
    public String Value{get;init;}
    
   

    internal Rol? Create()
    {
        throw new NotImplementedException();
    }
}