public interface ICharacterRepository
{
    Task<Character> FindUserByIdAsync(string id);
    void Add(Character character);
    Task SaveChangesAsync();
}

