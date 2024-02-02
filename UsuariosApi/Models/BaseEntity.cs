namespace UsuariosApi.Models;

public abstract class BaseEntity
{

    public BaseEntity Clone()
    {
        return (BaseEntity)MemberwiseClone();
    }
    
}