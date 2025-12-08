namespace Characters;

public abstract class Character
{
	public Character(string name)
	{
		_name=name;
	}

	protected string _class = "";
	protected string _story="";
    //ability scores
	protected string _name;
    protected int _wisdom = 6;
    protected int _charisma = 6;
    protected int _constitution = 6;
    protected int _health = 100;
    protected int _intelligence = 6;
    protected int _strength = 6;
    protected int _dexterity = 6;
    //combat stats
    protected int _meleeDamage = 5;
    protected int _shield = 0;
    protected int _rangedDamage = 2;
    protected string _action = "";

    //getters for attributes
    public string GetAction() => _action;
    public int GetShield()=> _shield;
    public int GetRangedDamaged()=> _rangedDamage;
	public string GetName()=>_name;
    public int GetCharisma() => _charisma;
    public int GetWisdom() => _wisdom;
    public int GetConstitution() => _constitution;
    public int GetDexterity() => _dexterity;
    public int GetIntelligence() => _intelligence;
    public int GetHealth() => _health;
    public int GetStrength()=> _strength;
	public string GetStory()=>_story;
	public string GetClass()=>_class;

    public int GetMeleeDamage() => _meleeDamage;
    
    //setters for attributes
	public void ChangeName(string name)
	{
		_name=name;
	}
    public void ChangeShield(int change) => _shield += change;
    public void ChangeRanged(int change) => _rangedDamage += change;
    public void ChangeMelee(int change) => _meleeDamage += change;
    public void ChangeCharisma(int change) => _charisma += change;
    public void ChangeWisdom(int change) => _wisdom += change;
    public void ChangeConstitution(int change) => _constitution += change;
    public void ChangeDexterity(int change) => _dexterity += change;
    public void ChangeIntelligence(int change) => _intelligence += change;
    public void ChangeStrength(int change) => _strength += change;
    public void ChangeHealth(int change) => _health += change;
	public void ChangeClass(string change)=>_class=change;
	public void ChangeAction(string change) => _action = change;

	public void DisplayStats()
    {
        Console.Write($"{GetName()} has: {GetHealth()} Health, {GetStrength()} Strength,\n" +
                      $"{GetIntelligence()} Intelligence, {GetDexterity()} Dexterity,\n" +
                      $"{GetConstitution()} Constitution, {GetWisdom()} Wisdom, and " +
                      $"{GetCharisma()} Charisma\n");
    }
}
