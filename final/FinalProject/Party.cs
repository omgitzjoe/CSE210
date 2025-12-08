using Characters;
public class Party
{
    private List<Character> _characters=new List<Character>();
    public List<Character> GetCharacters() => _characters;
    //add or remove members
    public void AddMember(Character character)
    {
        _characters.Add(character);
        Console.WriteLine($"{character.GetName()} has been added to the party!\n");
    }
    public void RemoveMember(Character character)
    {
        _characters.Remove(character);
        Console.WriteLine($"{character.GetName()} has been removed from the party!\n");
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
