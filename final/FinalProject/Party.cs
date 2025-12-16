namespace FinalProject;

public class Party
{
    private readonly List<Character> _characters = new List<Character>();
    
    public List<Character> GetCharacters() => _characters;
    
    //add or remove members
    public void AddMember(Character character)
    {
        _characters.Add(character);
    }
    
    public void RemoveMember(Character character)
    {
        _characters.Remove(character); 
    }
    
    public void DisplayMembers()
    {
        int index = 0;
        foreach (Character character in _characters)
        {
            Console.WriteLine($"{index}: {character.GetName()} the {character.GetClass()}");
            index++;
        }
    }
}
