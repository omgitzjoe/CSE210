namespace FinalProject;

public abstract class Character(string name)
{
	private string _class = "";
	
	private string _story = "";
    
	//ability scores
	private string _name = name;
    
	private int _wisdom = 6;
    
	private int _charisma = 6;
    
	private int _constitution = 6;
    
	private int _health = 100;
    
	private int _intelligence = 6;
    
	private int _strength = 6;
    
	private int _dexterity = 6;
    
	//combat stats
	private int _meleeDamage = 5;
    
	private int _shield;
    
	private int _rangedDamage = 2;
    
	private string _action = "";

	//getters for attributes
	public string GetAction() => _action;
    
	public int GetShield() => _shield;
    
	public int GetRangedDamaged() => _rangedDamage;
	
	public string GetName() => _name;
    
	public int GetCharisma() => _charisma;
    
	public int GetWisdom() => _wisdom;
    
	public int GetConstitution() => _constitution;
    
	public int GetDexterity() => _dexterity;
    
	public int GetIntelligence() => _intelligence;
    
	public int GetHealth() => _health;
    
	public int GetStrength() => _strength;
	public string GetStory() => _story;
	public string GetClass() => _class;
    
	public int GetMeleeDamage() => _meleeDamage;
	
	//setters for attributes
	public void ChangeName(string name)
	{
		_name = name;
	}
    
	public void ChangeShield(int change) => _shield += change;
    
	public void ChangeRanged(int change) => _rangedDamage += change;
    
	protected void ChangeMelee(int change) => _meleeDamage += change;
	
	protected void ChangeCharisma(int change) => _charisma += change;
    
	protected void ChangeWisdom(int change) => _wisdom += change;
    
	public void ChangeConstitution(int change) => _constitution += change;
	
	public void ChangeDexterity(int change) => _dexterity += change;
    
	protected void ChangeIntelligence(int change) => _intelligence += change;
    
	public void ChangeStrength(int change) => _strength += change;
    
	public void ChangeHealth(int change) => _health += change;
	
	protected void ChangeClass(string change) => _class = change;
	
	public void ChangeAction(string change) => _action = change;
	
	protected void ChangeStory(string change) => _story = change;
	
	public void DisplayStats() 
	{ 
		Console.Write($"{GetName()} has: {GetHealth()} Health, {GetStrength()} Strength,\n" + 
		              $"{GetIntelligence()} Intelligence, {GetDexterity()} Dexterity,\n" + 
		              $"{GetConstitution()} Constitution, {GetWisdom()} Wisdom, and " + 
		              $"{GetCharisma()} Charisma\n"); 
	}
}
